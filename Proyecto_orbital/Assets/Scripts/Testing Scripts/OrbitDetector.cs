using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitDetector : MonoBehaviour
{

    PlayerScorer playerScorer;

    public bool wallDetected;
    int wallCount;
    
    float _Timer = 50f;

    void Start()
    {
        playerScorer = GameObject.Find("ScoreController").GetComponent<PlayerScorer>();
        wallCount = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Orbital")
        {   
            wallDetected = true;
            // Aparece un aviso 50 puntos
            if(wallDetected) 
            {
                wallCount++;
                print("50 puntos por pasar cerca de un muro");
                wallDetected = false;
            }
            // Quería un timer
                while(_Timer > 0) {
                _Timer -= Time.deltaTime;
                print("Pasa otro muro suma mas puntos");

        }


            playerScorer.PlayerWallScorer(100); 
            wallCount = 0;
        }
        
    }

}
