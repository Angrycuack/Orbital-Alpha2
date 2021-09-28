using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOffSet : MonoBehaviour
{

    [Header("Variables que definir�n la posici�n de la c�mara")]
    [SerializeField] private float yOffset;
    [SerializeField] private float zOffset;
    [SerializeField] private Transform target;
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

    Vector3 offset;
    public float cameraY;
    public float cameraX;
    public float sensibility = 1f;
    // private float current_Rotation;
    //public float followDistance = 5f;

    void Start()
    {
        offset = transform.position - target.transform.position;
        Debug.Log(offset);
    }


    private void LateUpdate()
    {
        float desiredAngle = target.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(2f, desiredAngle, 0);
        float retardPosition = Mathf.Lerp(this.transform.position.x, target.position.x, cameraSpeed * Time.deltaTime);
        offset = new Vector3(retardPosition, target.position.y + yOffset, target.position.z + zOffset);
        GyrosCamRotation();
        transform.position = target.transform.position - (rotation * offset);
        transform.LookAt(target.transform);  

        //Se activa al hacer el efecto de c�mara golpeando contra algo.
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
    /// M�todo que se encarga de inicializar el efecto de shaking.
    /// </summary>
    public void Shake()
    {
        shaking = true;
        saveCameraPosition();
        timer = shakeDuration;
    }
    /// <summary>
    /// M�todo que se encarga de inicializar el efecto de In/Out.
    /// </summary>
    public void InOutEffect()
    {
        inOut = true;
        saveCameraPosition();
        timer = inOutDuration;
        finalPosition = new Vector3(this.transform.position.x, this.transform.position.y - 1, this.transform.position.z + 1);
    }
    /// <summary>
    /// M�todo que se encarga de guardar el estado de la c�mara actual para retomarla despu�s de los efectos.
    /// </summary>
    public void saveCameraPosition()
    {
        preEffectPosition = this.transform.localPosition;
    }

    void GyrosCamRotation() 
    {
        if(Input.gyro.attitude.y < -0.1 || Input.gyro.attitude.y > 0.1 )
        {

            
            float gyroY = Input.gyro.attitude.y;
            //Debug.Log(gyroY + "YYYYY");
            float yMin = -0.1f;
            float yMax = 0.1f;
            cameraY += Input.gyro.attitude.y * Time.deltaTime * sensibility;
            cameraY = Mathf.Clamp(cameraY, yMin, yMax);
            
            offset = Quaternion.AngleAxis(cameraY, Vector3.right) * offset;
            //rotation = Quaternion.Euler(2f, cameraY, 0);
            //transform.rotation = Quaternion.Euler(this.transform.rotation.x, cameraY, 0f);
            //transform.Rotate(new Vector3(0f, cameraY, 0f));

            
        } 
        else 
        {
            if(cameraY > 0)
            {
                
            }
        }
        
        if(Input.gyro.attitude.x < -0.1 || Input.gyro.attitude.x > 0.1 )
        {
            float gyroX = Input.gyro.attitude.x;
            //Debug.Log(gyroX + "XXXXX");
            float yMin = -0.1f;
            float yMax = 0.1f;
            cameraX += Input.gyro.attitude.x * Time.deltaTime * sensibility;
            cameraX = Mathf.Clamp(cameraX, yMin, yMax);

            Debug.Log(offset + "offset");
            offset = Quaternion.AngleAxis(cameraX, Vector3.up) * offset;
            // Voy a intertar usando el rotation cambiando sus propiedades
            //rotation = Quaternion.Euler(cameraX, 0, 0);
            // transform.rotation = Quaternion.Euler(cameraX, this.transform.rotation.y, 0f);
            // Debug.Log(this.transform.rotation);
            // transform.Rotate(new Vector3(cameraX, 0f, 0f));


        }
        else
        {
            if(cameraX > 0)
            {
                
            }
        }
    }
    
    private Quaternion GyroToUnity (Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }

}
