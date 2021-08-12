using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitDetector : MonoBehaviour
{
    PlayerScore playerScore;


    void Start()
    {
        playerScore = PlayerScore.FindObjectOfType<PlayerScore>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Orbital")
        {   
            playerScore.PlayerWallScore();   
        }
        
    }
}
