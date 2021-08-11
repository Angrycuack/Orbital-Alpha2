using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOffSet : MonoBehaviour
{

    [Header("Variables que definirán la posición de la cámara")]
    [SerializeField] private float yOffset;
    [SerializeField] private float zOffset;
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 targetPosition;
    [SerializeField] private float cameraSpeed;

    [Header("Variables para el efectos")]
    [SerializeField] private float shakeAmount;
    [SerializeField] private float shakeDuration;
    [SerializeField] private float inOutDuration;
    private Vector3 preEffectPosition;
    private Vector3 finalPosition;
    private bool shaking;
    private bool inOut;
    private float timer;

    private void Update()
    {
        float retardPosition = Mathf.Lerp(this.transform.position.x, target.position.x, cameraSpeed * Time.deltaTime);
        this.transform.position = new Vector3(retardPosition, target.position.y + yOffset, target.position.z + zOffset);
        //Se activa al hacer el efecto de cámara golpeando contra algo.
        if (shaking)
        {
            if (timer > 0)
            {
                transform.localPosition = preEffectPosition + Random.insideUnitSphere * shakeAmount;
                timer -= Time.deltaTime;
            }
            else
            {
                shaking = false;
                timer = 0;
                this.transform.localPosition = preEffectPosition;
            }
        }
        if (inOut)
        {
            if (timer > 0)
            {
                //Debug.Log(finalPosition);
                transform.localPosition = Vector3.Lerp(preEffectPosition, finalPosition, 0.3f);
                timer -= Time.deltaTime;
            }
            else
            {
                inOut = false;
                timer = 0;
                this.transform.position = Vector3.Lerp(this.transform.position,preEffectPosition, 0.3f); 
            }
        }
    }
    /// <summary>
    /// Método que se encarga de inicializar el efecto de shaking.
    /// </summary>
    public void Shake()
    {
        shaking = true;
        saveCameraPosition();
        timer = shakeDuration;
    }
    /// <summary>
    /// Método que se encarga de inicializar el efecto de In/Out.
    /// </summary>
    public void InOutEffect()
    {
        inOut = true;
        saveCameraPosition();
        timer = inOutDuration;
        finalPosition = new Vector3(this.transform.position.x, this.transform.position.y - 1, this.transform.position.z + 1);
    }
    /// <summary>
    /// Método que se encarga de guardar el estado de la cámara actual para retomarla después de los efectos.
    /// </summary>
    public void saveCameraPosition()
    {
        preEffectPosition = this.transform.localPosition;
    }
}
