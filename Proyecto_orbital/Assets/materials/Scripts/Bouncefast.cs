using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncefast : MonoBehaviour
{
    public Vector3 size;
    public Vector3 bouncing;
    public float bouncingrate;
    float rate;
    public float speed;
    Vector3 growfactor;
    bool gobig;
    bool returned;
    public Light pointlight;


    private void Start()
    {
        rate = bouncingrate;
        if (transform.localScale.x <= bouncing.x)
        {
            gobig = true;
        }
        growfactor.x = speed;
        growfactor.y = speed;
        growfactor.z = speed;

    }

    void Update()
    {
        rate -= Time.deltaTime;
        if (rate <= 0)
        {
            if (gobig == true)
            {
                if (gameObject.transform.localScale.x <= bouncing.x)
                {
                    gameObject.transform.localScale += growfactor;
                    pointlight.intensity += speed / 3;


                }
                else
                {
                    if (gameObject.transform.localScale.x <= size.x)
                    {
                        gameObject.transform.localScale -= growfactor;
                        pointlight.intensity -= speed / 3;
                    }
                    else
                    {
                        rate = bouncingrate;
                    }
                }
            }
            else
            {
                if (returned == false)
                {
                    if (gameObject.transform.localScale.x >= bouncing.x)
                    {
                        gameObject.transform.localScale -= growfactor;
                        pointlight.intensity -= speed / 3;

                    }
                    else
                    {
                        returned = true;
                    }
                }
                else
                {
                    if (gameObject.transform.localScale.x <= size.x)
                    {
                        gameObject.transform.localScale += growfactor;
                        pointlight.intensity += speed/3;
                    }
                    else
                    {
                        rate = bouncingrate;
                        returned = false;
                    }
                }
                
            }
            
        }
    }
}
