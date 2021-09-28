using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMoves : MonoBehaviour
{
    // Llamada a la Transform de la camara
    [SerializeField]
    private Transform cameraTransform;

    // Waypoint Configuration
    public GameObject[] waypoints;
    public int currentWP = 0;
    public float dist_WP_detect = 1f;

    // velocidad que va la esfera
    [SerializeField]
    public float speed = 0;

    //velocidad rotacion
    public float rotation_Speed = 0.5f;

    // Score del jugador get from distance
    private PlayerScorer pScorer;
    int score;
    float get_score;

    // ultima posicion de la esfera
    private Vector3 player_lastPosition;
    private Vector3 player_currentPosition;
    Camera m_MainCamera;


    // la distancia recurridad de su ultima posicion hasta la actual
    public float distance;
    float prevPlayerZ;
    
    // LinedRender 
    private LineRenderer lineRenderer;
    //private float t = 1;
    void Start()
    {
        
        player_currentPosition = this.transform.position;
        prevPlayerZ = transform.position.z;
        score = 0;

        pScorer = FindObjectOfType<PlayerScorer>();
        m_MainCamera = Camera.main;
    }

    void Update()
    {
        PlayerScoreDistance();
    }

    void LateUpdate()
    {
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        WaypointFollower();
        
        // player_lastPosition = transform.position;
       
        // distance = Vector3.Distance(player_currentPosition, transform.position);

        // Vector3 target = Waypoint.position;

        // transform.position = Vector3.MoveTowards(player_lastPosition, Vector3.Lerp(player_lastPosition, target, t), speed);
    }

    void PlayerScoreDistance() 
    {
        if(prevPlayerZ < this.transform.position.z) 
        {
            get_score += this.transform.position.z - prevPlayerZ;
            prevPlayerZ = this.transform.position.z;
            score = ((int) get_score);
        }
        pScorer.PlayerScoreIncrementer(score, 0);
    }

    void WaypointFollower() 
    {
        if(waypoints.Length == 0) return;

            Vector3 lookAtGoal = new Vector3(waypoints[currentWP].transform.position.x, 
                                            this.transform.position.y, 
                                            waypoints[currentWP].transform.position.z);

            Vector3 direction = lookAtGoal - this.transform.position;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                        Quaternion.LookRotation(direction), 
                                        Time.deltaTime*rotation_Speed);
            

            if(direction.magnitude < dist_WP_detect)
            {
                currentWP++;
                if(currentWP >= waypoints.Length)
                {
                    currentWP = 0;
                }
            }
            this.transform.Translate(0,0,speed*Time.deltaTime);
    }

    void DeleteElementWaypoint<T>(ref T[] wp, int index) 
    {
        for(int i = index; i < wp.Length -1; i++)
        {
            wp[i] = wp[i + 1];
        }
        Array.Resize(ref wp, wp.Length -1);
    }

    void LineRendererWaypoints()
    {

    }
}
