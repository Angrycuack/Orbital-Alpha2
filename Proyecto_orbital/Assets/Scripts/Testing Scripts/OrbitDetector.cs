using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitDetector : MonoBehaviour
{

    PlayerScorer playerScorer;

    private int level;
    bool collided = false;
    
    float _Timer;
    float multiplyer;


    BoxCollider colliderNear;

    void Start()
    {
        playerScorer = FindObjectOfType<PlayerScorer>();
        _Timer = 0;

        colliderNear = this.gameObject.GetComponent<BoxCollider>();


    }

    IEnumerator OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Orbital") 
        {
            Debug.LogWarning(level + " level");
            switch (level)
            {
                case 0:
                    Debug.LogWarning("20 p" + _Timer);
                    print("20 puntos");
                    playerScorer.PlayerNearWallScore(20);
                    playerScorer.PlayerScoreDisplay("50");
                    _Timer = 6f;
                    level ++;
                    break;
                case 1:
                    Debug.LogWarning("50 p" + _Timer);
                    print("50");
                    playerScorer.PlayerNearWallScore(50);
                    playerScorer.PlayerScoreDisplay("110");
                    _Timer = 5f;
                    level++;
                    break;
                case 2:
                    Debug.LogWarning("110 p" + _Timer);
                    print("110");
                    playerScorer.PlayerNearWallScore(110);
                    playerScorer.PlayerScoreDisplay("180");
                    _Timer = 4f;
                    level ++;
                    break;
                case 3:
                    Debug.LogWarning("180 p"+ _Timer);
                    print("180");
                    playerScorer.PlayerNearWallScore(180);
                    playerScorer.PlayerScoreDisplay("234");
                    _Timer = 3f;
                    level ++;
                    break;
                case 4:
                    Debug.LogWarning("234 p" + _Timer);
                    print("234");
                    playerScorer.PlayerNearWallScore(234);
                    playerScorer.PlayerScoreDisplay("327");
                    _Timer = 2f;
                    level++;
                    break;
                case 5:
                    Debug.LogWarning("327 p" + _Timer);
                    print("327");
                    playerScorer.PlayerNearWallScore(327);
                    playerScorer.PlayerScoreDisplay("500");
                    _Timer = 1f;
                    level ++;
                    break;

            }
            colliderNear.enabled = false;
            // float norTime = 0;
            // while(norTime <= 1f) 
            // {
            //     norTime += Time.deltaTime / _Timer;
            //     Debug.Log(norTime);
            //     yield return null;
            // }
            yield return new WaitForSeconds(_Timer);
            level = 0;
                Debug.Log("Thank you!");
        }
    } 
    void ComboScorer() 
    {
        
    }

}
