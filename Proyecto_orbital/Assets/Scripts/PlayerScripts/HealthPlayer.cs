using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    private CentralSphereMovement _player;
    public static bool invencible;

    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<CentralSphereMovement>();

        
    }
    private void OnCollisionEnter(Collision collision)
    {

        // efecto invencible
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (!invencible)
            {
                DestroyOrbit();
            }
            else
            {
                Destroy(collision.gameObject);
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraOffSet>().Shake();
            }
        // recoge PowerUP
        }
        if (collision.gameObject.CompareTag("PowerUp"))
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraOffSet>().InOutEffect();
            _player.PowerUp(collision.gameObject.name);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("IronEnemy"))
        {
            DestroyOrbit();
        }

    }

    public void Invencible(bool state)
    {
        Debug.Log("Invencible: " + state);
        invencible = state;
    }

    private void DestroyOrbit()
    {
        Destroy(this.gameObject);
        GameController.instance.AddOrbit(false);
    }
}
