using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FullRotationDetector : MonoBehaviour
{
    GameObject orbit;
    private Vector3 orbitPosition;
    GameObject trigger_Position;
    float old_position;

    GameController gameController;

    public TMP_Text msg_Text;
    public GameObject msgText_Object;

    SphereCollider colliderIsTrigger;
    // bool onTriggerExit;

    private int numClic = 0;
    public float timerInt = 5;
    public bool timerIntRunning = false;

    PlayerScorer playerScorer;
    public int set_score = 10;
    void Start()
    {
        orbit = GameObject.Find("Orbital");
        trigger_Position = this.gameObject;
        trigger_Position.transform.position = new Vector3(0, 0, 0);
        colliderIsTrigger = this.gameObject.GetComponent<SphereCollider>();
        orbit = GameObject.FindWithTag("Orbital");

        playerScorer = FindObjectOfType<PlayerScorer>();
        gameController = FindObjectOfType<GameController>();
    }


    void Update()
    {
        if (orbit == null) 
        {
            orbit = GameObject.FindWithTag("Orbital");
        }
 
        
        // Debug.LogError("orbit position " + save_orbit_position);
        SetTriggerPosition();
        InterruptorCollider();
        if(!gameController.isGameActive)
        {
            msgText_Object.SetActive(false);
        }

    }

    private void SetTriggerPosition()
    {
        
        if (Input.GetMouseButtonDown(0))
        {

            if (orbit != null) 
            {
                orbitPosition = orbit.transform.position;
            }
            // Corregido
             colliderIsTrigger.enabled = false;
             colliderIsTrigger.isTrigger = false;
            // posibles solo
            //Debug.Log("position " + orbitPosition);
            trigger_Position.transform.position = orbitPosition;
            float last_trigger_pos = trigger_Position.transform.position.z;
            Debug.Log(last_trigger_pos);
            //Debug.LogWarning("trigger position " + trigger_Position);
            if (numClic == 0) 
            {
                timerIntRunning = true;
                timerInt = 5;
                msg_Text.text = "Mision 360";
                StartCoroutine(DisplayTimer());
                InterruptorCollider();
                numClic = 1;
                Debug.Log(numClic);
            } 
            else if (numClic == 1) 
            {
                timerIntRunning = true;
                timerInt = 5;
                msg_Text.text = "Mision 360";
                StartCoroutine(DisplayTimer());
                InterruptorCollider();
                numClic = 0;
            }

            
            
        }
    }

    void OnTriggerExit(Collider other)
    {
        
        if (other.gameObject.CompareTag("Orbital")) 
        {
            Debug.Log("Hello, Collider");
            msgText_Object.SetActive(true);
            msg_Text.text = "Enhorabuena! Conseguiste " + set_score + " puntos";
            
            playerScorer.PlayerScoreIncrementer(0, set_score);


            //colliderIsTrigger.isTrigger = false;   
        }
    }
    IEnumerator DisplayTimer()
    {
        msgText_Object.SetActive(true);
        yield return new WaitForSeconds(1f);
        msgText_Object.SetActive(false);
    }

    void InterruptorCollider () 
    {
        if(timerIntRunning)
        {
            if(timerInt > 0)
            {
                timerInt -= Time.deltaTime;
            }
            else{
                Debug.Log("Hello, Michael!");
                colliderIsTrigger.enabled = true;
                colliderIsTrigger.isTrigger = true;
                timerInt = 0;
                timerIntRunning = false;
            }
        }

    }
}
