using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitDetector : MonoBehaviour
{
    private int pointsToAdd = 10;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Orbital")
        {

            var orbit = other.CompareTag("Orbital");
            Debug.Log(orbit + " detected " + pointsToAdd);
            ScoreController.PointsWhenOrbitClosetoWall(pointsToAdd);
        }
        
    }
}
