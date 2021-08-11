using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    World_settings world_settings;
    public GameObject zone_to_destroy;
    bool do_once;

    private void Start()
    {
        world_settings = FindObjectOfType<World_settings>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other == other.CompareTag("Player"))
        {
            if (do_once == false)
            {
                world_settings.exp += 5;
                zone_to_destroy.SetActive(false);
                do_once = true;
            }
        } 
    }
}
