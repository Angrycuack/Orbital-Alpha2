using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsController : MonoBehaviour
{
    private int current_points;
    private int _distance;

    Transform player_distance;

    void Start()
    {
        player_distance = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        print(player_distance.name);

        current_points = 0;
        StartCoroutine(PointsDistanceSystem());
    }


    void Update()
    {
        //print(player_distance.transform.position.z);
        _distance = ((int)player_distance.transform.position.z);
    }

    IEnumerator PointsDistanceSystem ()
    {
        Debug.Log("Hello" + _distance);
        if (_distance >= current_points)
        {
            _distance = 1;
            while (_distance < 360)
            {
                print("Welcome" + _distance);
            }
            
        }
        yield return null;
    }
}
