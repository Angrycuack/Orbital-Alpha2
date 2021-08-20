using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitDetector : MonoBehaviour
{

    PlayerScorer playerScorer;

    public bool wallDetected;
    int level;
    
    float _Timer;
    float multiplyer;


    void Start()
    {
        playerScorer = GameObject.Find("ScoreController").GetComponent<PlayerScorer>();
        level = 0;
    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.gameObject.tag == "Orbital")
    //     {   

    //         //Timer de un segundo
    //         //reset timer
    //         // aumentar multiplicador.
    //         StartCoroutine(WallScorerConditions());
    //         // wallDetected = true;
    //         // // Aparece un aviso 50 puntos
    //         // if(wallDetected) 
    //         // {
    //         //     wallCount++;
    //         //     print("50 puntos por pasar cerca de un muro");
    //         //     wallDetected = false;
    //         // }
    //         //     while(_Timer > 0) {
    //         //     _Timer -= Time.deltaTime;
    //         //     print("Pasa otro muro suma mas puntos");
    //         // playerScorer.PlayerScoreIncrementer(0, 150); 
    //         // wallCount = 0;
    //         //}
    //     }
    // }

    IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Orbital") 
        {
            wallDetected = true;
            if(wallDetected) 
            {   
                Debug.LogWarning(level);
                if(level == 00) 
                {
                    print("50 points");
                    _Timer = 5f;
                    level ++;
                }
                else if (level == 1)
                {
                    print("100 points");
                    _Timer = 4f;
                    level ++;
                }
                else if (level == 2) 
                {
                    print("200 points");
                    _Timer = 3f;
                    level ++;

                }
                else if (level == 3)
                {
                    print("300 points");
                    _Timer = 2f;
                    level ++;
                }
                else if (level == 4)
                {
                    print("400 points");
                    _Timer = 1f;
                }            
            }
            yield return new WaitForSeconds(_Timer);
            level = 0;
            wallDetected = false;
            if (!wallDetected)
            {
                Debug.Log("Thank you!");
                
            }   
        }
    } 


}
