using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class world_generator : MonoBehaviour
{
    public GameObject Next_spawn;
    GameObject zone;
    public Vector3 spawn_offset;
    public GameObject[] zones1;
    public GameObject[] zones2;
    public GameObject[] zones3;
    public GameObject[] zones4;
    public World_settings world_setings;
    bool do_once;
    DevLog_zone devzone;
    public string code;

    bool alpha = true;

    private void Start()
    {
        zone = zones1[Random.Range(0, zones1.Length)];
        Debug.Log(zones1.Length);
        Debug.Log(zone);
        if (alpha == false)
        {
            if (world_setings.dificulty <= 1)
            {
                zone = zones1[Random.Range(0, zones1.Length + 1)];
            }
            if (world_setings.dificulty <= 2)
            {
                zone = zones2[Random.Range(0, zones2.Length + 1)];
            }
            if (world_setings.dificulty <= 3)
            {
                zone = zones3[Random.Range(0, zones3.Length + 1)];
            }
            if (world_setings.dificulty <= 4)
            {
                zone = zones4[Random.Range(0, zones4.Length + 1)];
            }
        }
       
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {

            if (do_once == false)
            {
                devzone = FindObjectOfType<DevLog_zone>();
                devzone.codezone = code;
                Instantiate(zone, new Vector3((Next_spawn.transform.position.x + spawn_offset.x), (Next_spawn.transform.position.y + spawn_offset.y), (Next_spawn.transform.position.z + spawn_offset.z)), Quaternion.identity);
                do_once = true;
            }
        }
    }
}
