using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin_or_power : MonoBehaviour
{
    public GameObject coin;
    public GameObject[] power;
    public int Spawn_probability;
    int Spawn_prob;
    public int Power_probability;
    int Power_prob;


    // Start is called before the first frame update
    void Start()
    {
        Spawn_prob = Random.Range(0, 100);
        if (Spawn_prob <= Spawn_probability)
        {
            Power_prob = Random.Range(0, 100);
            if (Power_prob <= Power_probability)
            {
                Instantiate(power[Random.Range(0, power.Length)], new Vector3(0, 0, 0), Quaternion.identity);
            }
            else
            {
                Instantiate(coin, new Vector3(0, 0, 0), Quaternion.identity);
            }

            
        }
    }

}
