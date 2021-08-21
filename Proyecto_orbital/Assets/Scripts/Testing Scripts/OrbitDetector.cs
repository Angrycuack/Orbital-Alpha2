using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitDetector : MonoBehaviour
{

    PlayerScorer playerScorer;

    private int level = 0;
    
    float _Timer;
    float multiplyer;


    void Start()
    {
        playerScorer = FindObjectOfType<PlayerScorer>();

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
            Debug.LogWarning(level);
            switch (level)
            {
                case 1:
                    print("50");
                    playerScorer.PlayerScoreIncrementer(0,50);
                    _Timer = 5f;
                    level++;
                    break;
                case 2:
                    print("110");
                    playerScorer.PlayerScoreIncrementer(0,110);
                    _Timer = 4f;
                    level ++;
                    break;
                case 3:
                    print("180");
                    playerScorer.PlayerScoreIncrementer(0,180);
                    _Timer = 3f;
                    level ++;
                    break;
                case 4:
                    print("234");
                    playerScorer.PlayerScoreIncrementer(0,234);
                    _Timer = 2f;
                    level++;
                    break;
                case 5:
                    print("327");
                    playerScorer.PlayerScoreIncrementer(0,327);
                    level ++;
                    break;
                default:
                    print("20 puntos");
                    playerScorer.PlayerScoreIncrementer(0, 20);
                    _Timer = 6f;
                    level ++;
                    break;
            }
            yield return new WaitForSeconds(_Timer);
            level = 0;
                Debug.Log("Thank you!");
        }
    } 


}
