using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointController : MonoBehaviour
{
    public GameObject[] waypoints;
    int currentWP = 0;

    float accuracy = 1.0f;
    float rotSpeed = 0.5f;

    void Start()
    {
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
    }

    void LateUpdate()
    {
        if(waypoints.Length == 0) return;

        Vector3 lookAtGoal = new Vector3(waypoints[currentWP].transform.position.x, 
                                        this.transform.position.y, 
                                        waypoints[currentWP].transform.position.z);

        Vector3 direction = lookAtGoal - this.transform.position;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                    Quaternion.LookRotation(direction), 
                                    Time.deltaTime*rotSpeed);

        if(direction.magnitude < accuracy)
        {
            currentWP++;
        }
    }
}
