using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GyroController : MonoBehaviour
{
    Gyroscope gC;

    public float cameraX;
    public float cameraY;
    public float gyroX;
    public float gyroY;

    public float speedRotation;
    [SerializeField]
    public GameObject target;
    
    public float xMin = -10f;
    public float xMax = 20f;
    public float yMin = -20f;
    public float yMax = 20f;

    void Start()
    {
        if(SystemInfo.supportsGyroscope)
        {
            gC = Input.gyro;
            gC.enabled = true;
        }
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>

    void Update()
    
    {
        gyroX = Input.gyro.attitude.x;
        gyroY = Input.gyro.attitude.y;

        // Funcion para el movimiento.
        GyroMovements();
        target.transform.rotation = Quaternion.Euler(cameraX, cameraY, 0f);

        //if (SystemInfo.supportsGyroscope) { transform.rotation = GyroToUnity(Input.gyro.attitude); }

    }

    void GyroMovements() 
    {
        if (gyroX >= 0.1 || gyroX <= -0.1)
        {
            cameraX += Time.deltaTime * gyroX * speedRotation;
            cameraX = Mathf.Clamp(cameraX, xMin, xMax);
        }
        else
        {
            cameraY = Mathf.Lerp(target.transform.position.x, cameraX, .5f);
        }
        if (gyroY >= 0.1 || gyroY <= -0.1)
        {
            cameraY += Time.deltaTime * gyroY * speedRotation;
            cameraY = Mathf.Clamp(cameraY, yMin, yMax);
        }
        else
        {
            cameraY = Mathf.Lerp(target.transform.position.y, cameraY, .5f);
        }
    }
    // Calibration 
    private Quaternion GyroToUnity (Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }

}
