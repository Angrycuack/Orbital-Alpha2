using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class OrbitDetector : MonoBehaviour
{
    PlayerScore playerScore;

    //Timer
    private float previous_timer = 0;
    private float current_timer;


    void Start()
    {
        playerScore = PlayerScore.FindObjectOfType<PlayerScore>();

        ;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Orbital")
        {   
            playerScore.PlayerWallScore();   
        }

        
    }

}
