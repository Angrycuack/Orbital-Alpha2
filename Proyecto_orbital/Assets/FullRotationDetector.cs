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
            // posibles solo
            //Debug.Log("position " + orbitPosition);
            trigger_Position.transform.position = orbitPosition;
            float last_trigger_pos = trigger_Position.transform.position.z;
            Debug.Log(last_trigger_pos);
            //Debug.LogWarning("trigger position " + trigger_Position);
                msg_Text.text = "Deja que la orbita de una vuelta entera";
                StartCoroutine(TriggerTimer());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Orbital")) 
        {
            msgText_Object.SetActive(true);
            msg_Text.text = "Enhorabuena! Conseguiste " + set_score + " puntos";
            playerScorer.PlayerScoreIncrementer(0, set_score);


            //colliderIsTrigger.isTrigger = false;   
        }
    }
    IEnumerator TriggerTimer()
    {
        msgText_Object.SetActive(true);
        yield return new WaitForSeconds(1f);
        msgText_Object.SetActive(false);
        yield return new WaitForSeconds(5f); 
        colliderIsTrigger.enabled = true;
        colliderIsTrigger.isTrigger = true;
        yield return new WaitForSeconds(2f);
        msgText_Object.SetActive(false);
        //colliderIsTrigger.enabled = true;
        //yield return new WaitForSeconds(1f);
        

    }
}
