using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GyroController : MonoBehaviour
{
    Gyroscope gC;

    public float gCrotationX;
    public float gCrotationY;
    public float gCrotationZ;

    public float cameraX;
    public float cameraY;
    public float gyroX;
    public float gyroY;
    public float numX;
    public float numY;
    public float speedRotation;
    [SerializeField]
    public GameObject cameraRotation;
    public GameObject gyroRotation;
    
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
        cameraRotation = GameObject.Find("Camera");
        Debug.Log(cameraRotation.transform.rotation);
        gyroRotation = GameObject.Find("GyroController");

        
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>

    void FixedUpdate()
    
    {
        gyroX = Input.gyro.attitude.x;
        gyroY = Input.gyro.attitude.y;

        // Funcion para el movimiento.
        GyroMovements();
        
        
        

        cameraRotation.transform.rotation = Quaternion.Euler(numX, numY, 0f);

        //if (SystemInfo.supportsGyroscope) { transform.rotation = GyroToUnity(Input.gyro.attitude); }

    }

    void GyroMovements() 
    {
        if (gyroX >= 0.1 || gyroX <= -0.1)
        {
            numX += Time.deltaTime * gyroX * speedRotation;
            numX = Mathf.Clamp(numX, xMin, xMax);
        }
        else
        {
            numX = 0;
        }
        if (gyroY >= 0.1 || gyroY <= -0.1)
        {
            numY += Time.deltaTime * gyroY * speedRotation;
            numY = Mathf.Clamp(numY, yMin, yMax);
        }
        else
        {
            numY = 0;
        }
    }
// Puede quitarlo
    
    private Quaternion GyroToUnity (Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }

}
