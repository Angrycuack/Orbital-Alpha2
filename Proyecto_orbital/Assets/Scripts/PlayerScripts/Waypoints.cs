using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public Color rayColor = Color.black;
    public List<Transform> wayPoints = new List<Transform>();
    Transform[] theArray;
    private void OnDrawGizmos()
    {
        Gizmos.color = rayColor;
        theArray = GetComponentsInChildren<Transform>();
        wayPoints.Clear();

        foreach (Transform wayPoint in theArray)
        {
            if (wayPoint != this.transform)
            {
                wayPoints.Add(wayPoint);
            }
        }

        for (int i = 0; i < wayPoints.Count; i++)
        {
            Vector3 position = wayPoints[i].position;
            //Debug.Log(position);
            if (i > 0)
            {
                Vector3 previous = wayPoints[i - 1].position;
                Gizmos.DrawLine(previous, position);
                Debug.Log("Previous " + previous);
            }
        }
    }
}
