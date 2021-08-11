using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Waypoints wayPointsToFollow;

    public int currentWayPoint = 0;
    public float speed;
    private float reachDistance = 1.0f;
    public float rotationSpeed = 5.0f;
    public string wayPointsName;
    public static float playerScore;

    public GameObject Player;

    Vector3 last_position;
    Vector3 current_position;


    void Start()
    {
        wayPointsToFollow = GameObject.Find(wayPointsName).GetComponent<Waypoints>();
        Debug.Log(wayPointsToFollow);
        last_position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(wayPointsToFollow.wayPoints[currentWayPoint].position, transform.position);
        transform.position = Vector3.MoveTowards(transform.position, wayPointsToFollow.wayPoints[currentWayPoint].position, Time.deltaTime * speed);

        if (distance <= reachDistance)
        {
            currentWayPoint++;
        }

        playerScore = ((int)distance);
        Debug.Log(playerScore);
    }

    //void detectPlayerPosition()
    //{
    //    float logX = Player.transform.position.x;
    //    float logY = Player.transform.position.y;
    //    float logZ = Player.transform.position.z;
    //    Debug.Log("X:" + logX + "Y:" + logY + "Z:" + logZ);
    //}
}
