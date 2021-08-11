using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [Header ("Asignar prefabs de los powerUps y cantidad")]
    [SerializeField] public GameObject DestructionPU;
    [SerializeField] public int sizeDestructionPU;
    GameObject[] poolDestructionPU; // grupacion
    [SerializeField] public GameObject FrostPU;
    [SerializeField] public int sizeFrostPU;
    GameObject[] poolFrostPU; // grupacion
    [SerializeField] public GameObject GhostPU;
    [SerializeField] public int sizeGhostPU;
    GameObject[] poolGhostPU; // grupacion
    [SerializeField] public GameObject MultiplePU;
    [SerializeField] public int sizeMultiplePU;
    GameObject[] poolMultiplePU; // grupacion
    [SerializeField] public GameObject NearPU;
    [SerializeField] public int sizeNearPU;
    GameObject[] poolNearPU; // grupacion
    [SerializeField] public GameObject SpeedPU;
    [SerializeField] public int sizeSpeedPU;
    GameObject[] poolSpeedPU; // grupacion

    


    [Header ("Asignar el Jugador y el target position final")]
    public GameObject player;
    Vector3 playerPosition;

    public GameObject target;
    Vector3 targetEndPosition;

    //private bool go = true;
    void Awake()
    {
        player = GameObject.Find("Player");
        playerPosition = player.transform.position;
        target = GameObject.Find("Final WayPoints");
        targetEndPosition = target.transform.position;
        PowerUpsRecharger();
    }



    void Start()
    {
        // Debug.Log("Posicion del jugador" + playerPosition);
        // Debug.Log("Posicion target " + targetEndPosition);
        
    }

    /// <summary>
    /// Se inicializa con el numero de powerUps asignado.
    /// </summary>
    void PowerUpsRecharger()
    {
        poolDestructionPU = new GameObject[sizeDestructionPU];
        poolFrostPU = new GameObject[sizeFrostPU];
        poolGhostPU = new GameObject[sizeGhostPU];
        poolMultiplePU = new GameObject[sizeMultiplePU];
        poolNearPU = new GameObject[sizeNearPU];
        poolSpeedPU = new GameObject[sizeSpeedPU];

        if(sizeDestructionPU != 0)
        {
            for (int i = 0; i < poolDestructionPU.Length; i++)
            {
                float posZ = targetEndPosition.z;

                float randomPosition = Random.Range(0, posZ-5);
                if (i < sizeDestructionPU)
                {
                    poolDestructionPU[i] = Instantiate(DestructionPU, new Vector3(0, 0, randomPosition), Quaternion.identity);
                    poolDestructionPU[i].SetActive(true); // Cambiar a false cuando se implementa
                }


            }
        }

        if (sizeFrostPU != 0)
        {
            for (int i = 0; i < poolFrostPU.Length; i++)
            {
                float posZ = targetEndPosition.z;

                float randomPosition = Random.Range(0, posZ-5);
                float randomizedX = Random.Range(-5f, 5f);
                if (i < sizeFrostPU)
                {
                    poolFrostPU[i] = Instantiate(FrostPU, new Vector3(randomizedX, 0, randomPosition), Quaternion.identity);
                    poolFrostPU[i].SetActive(true);
                }


            }
        }

        if (sizeGhostPU != 0)
        {
            for (int i = 0; i < poolGhostPU.Length; i++)
            {
                float posZ = targetEndPosition.z; // eje Z
                float randomizedX = Random.Range(-10f, 10f); // Eje X 
                float randomPosition = Random.Range(0, posZ-5);
                if (i < sizeGhostPU)
                {
                    poolGhostPU[i] = Instantiate(GhostPU, new Vector3(randomizedX, 0, randomPosition), Quaternion.identity);
                    poolGhostPU[i].SetActive(true);
                }


            }
        }

        if (sizeMultiplePU != 0)
        {
            for (int i = 0; i < poolMultiplePU.Length; i++)
            {
                float posZ = targetEndPosition.z;
                float randomizedX = Random.Range(-10f, 10f); // Eje X 
                float randomPosition = Random.Range(0, posZ-5);
                if (i < sizeMultiplePU)
                {
                    poolMultiplePU[i] = Instantiate(MultiplePU, new Vector3(randomizedX, 0, randomPosition), Quaternion.identity);
                    poolMultiplePU[i].SetActive(true); // Cambiar a false cuando se implementa
                }


            }
        }

        if (sizeNearPU != 0)
        {
            for (int i = 0; i < poolNearPU.Length; i++)
            {
                float posZ = targetEndPosition.z;
                float randomizedX = Random.Range(-10f, 10f); // Eje X 
                float randomPosition = Random.Range(0, posZ);
                if (i < sizeNearPU)
                {
                    poolNearPU[i] = Instantiate(NearPU, new Vector3(randomizedX, 0, randomPosition), Quaternion.identity);
                    poolNearPU[i].SetActive(true); // Cambiar a false cuando se implementa
                }


            }
        }

        if (sizeSpeedPU != 0)
        {
            for (int i = 0; i < poolSpeedPU.Length; i++)
            {
                float posZ = targetEndPosition.z;
                float randomizedX = Random.Range(-10f, 10f); // Eje X 
                float randomPosition = Random.Range(0, posZ);
                if (i < sizeSpeedPU)
                {
                    poolSpeedPU[i] = Instantiate(SpeedPU, new Vector3(randomizedX, 0, randomPosition), Quaternion.identity);
                    poolSpeedPU[i].SetActive(true); // Cambiar a false cuando se implementa
                }


            }
        }


    }

}
