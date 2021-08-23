using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitDetector : MonoBehaviour
{

    PlayerScorer playerScorer;
    BoxCollider colliderNear;

    void Start()
    {
        playerScorer = FindObjectOfType<PlayerScorer>();
        colliderNear = this.gameObject.GetComponent<BoxCollider>();
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Orbital")
        {
            playerScorer.OrbitNearWall();
            colliderNear.enabled = false;
        }
            
    } 


}
