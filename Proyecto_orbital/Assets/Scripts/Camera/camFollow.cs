using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camFollow : MonoBehaviour
{
    public GameObject target;
    Vector3 offset;

    public float cameraY;
    public float cameraX;
    public float sensibility;

    void Start()
    {
        offset = target.transform.position - transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float desiredAngle = target.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(2f, desiredAngle, 0);
                if(Input.gyro.attitude.y < -0.1 || Input.gyro.attitude.y > 0.1 )
        {

            
            float gyroY = Input.gyro.attitude.y;
            //Debug.Log(gyroY + "YYYYY");
            float yMin = -0.1f;
            float yMax = 0.1f;
            cameraY += Input.gyro.attitude.y * Time.deltaTime * sensibility;
            cameraY = Mathf.Clamp(cameraY, yMin, yMax);
            
            offset = Quaternion.AngleAxis(cameraY, Vector3.right) * Vector3.ClampMagnitude(offset, 5f);
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

            Debug.Log(offset + "offset beforee");
            offset = Quaternion.AngleAxis(cameraX, Vector3.up) * Vector3.ClampMagnitude(offset, 20f);
            Debug.Log(offset + "offset after");
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

        transform.position = target.transform.position - (rotation * offset);

        transform.LookAt(target.transform);        
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
}
