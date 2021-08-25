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

        if(gyroX >= 0.15)
        {
            Debug.LogWarning("Right");
            numX += Time.deltaTime * speedRotation;


        }
        else if (gyroX <= -0.15)
        {
            Debug.LogWarning("Left");
            numX -= Time.deltaTime * speedRotation;
        }
        else
        {
            numX = 0;
        }

        if(gyroY >= 0.2) 
        {
            Debug.Log("Down");
            numY += Time.deltaTime * speedRotation;
        }
        else if (gyroY <= -0.4)
        {
            Debug.Log("Up");
            numY -= Time.deltaTime * speedRotation;
        }
        else
        {
            numY = 0;
        }

        cameraRotation.transform.rotation = Quaternion.Euler(numX, numY, 0f);

        //if (SystemInfo.supportsGyroscope) { transform.rotation = GyroToUnity(Input.gyro.attitude); }

    }
    private Quaternion GyroToUnity (Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }

}
