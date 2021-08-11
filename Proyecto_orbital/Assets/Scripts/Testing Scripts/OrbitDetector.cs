using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitDetector : MonoBehaviour
{
    private int pointsToAdd = 10;
    PlayerScore playerScore;


    void Start()
    {
        playerScore = PlayerScore.FindObjectOfType<PlayerScore>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Orbital")
        {   
            playerScore.PlayerWallAddScore(pointsToAdd);   
        }
        
    }
}
