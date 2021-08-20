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

    public TMP_Text msg_Text;
    public GameObject msgText_Object;

    SphereCollider colliderIsTrigger;

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
    }


    void Update()
    {
        if (orbit == null) 
        {
            orbit = GameObject.FindWithTag("Orbital");
        }
 
        
        // Debug.LogError("orbit position " + save_orbit_position);
        SetTriggerPosition();

    }

    private void SetTriggerPosition()
    {
        
        if (Input.GetMouseButtonDown(0))
        {

            
            if (orbit != null) 
            {
                orbitPosition = orbit.transform.position;
            }
            if(colliderIsTrigger.isTrigger) {
                colliderIsTrigger.isTrigger = false;
            }
            //Debug.Log("position " + orbitPosition);
            trigger_Position.transform.position = orbitPosition;
            //Debug.LogWarning("trigger position " + trigger_Position);
            msg_Text.text = "Deja que la orbita de una vuelta entera";
            StartCoroutine(TriggerTimer());
        }
    }

    void OnTriggerExit(Collider other)
    {
        
        if (other.gameObject.CompareTag("Orbital")) 
        {
            msgText_Object.SetActive(true);
            msg_Text.text = "Enhorabuena! Conseguiste" + set_score + " puntos";
            playerScorer.PlayerScoreIncrementer(0, set_score);

            //colliderIsTrigger.isTrigger = false;
            
            
        }
    }
    IEnumerator TriggerTimer()
    {
        msgText_Object.SetActive(true);
        yield return new WaitForSeconds(2f);
        colliderIsTrigger.isTrigger = true;
        yield return new WaitForSeconds(2f);
        msgText_Object.SetActive(false);
        //colliderIsTrigger.enabled = true;
        //yield return new WaitForSeconds(1f);
        

    }
}
