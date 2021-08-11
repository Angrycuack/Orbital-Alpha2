using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsSpawner : MonoBehaviour
{
    [Header ("Array para los prefabs de los muros")]
    public GameObject[] wallsArray;

    private float timeCurrentPlayerPosition;
    private float currentPlayerPosition;

    private Vector3 lastPlayerPosition;
    private float pointsToSpawnWall;
    // private int indexWalls = 0;
    private int wallsCounted;
    public GameObject Player;

    [SerializeField] private float whenToSpawnWall;
    private float timer;
    //float cdTimer = 2f;

    private int getWallsCount;

    void Awake()
    {
        
    }
    void Start()
    {
        lastPlayerPosition = Player.transform.position;
        StartCoroutine(WallSpawnIn());

    }
    void Update()
    {
        currentPlayerPosition = Player.transform.position.z;
        //Debug.Log("Posicion del jugador " + currentPlayerPosition);
        getWallsCount = CountWalls();
        //if (cdTimer > 0)
        //{
        //    cdTimer -= Time.deltaTime;
        //}

        timer = Time.time;
        // Debug.Log("Time: " + timer);
    }
    void FixedUpdate ()
    {
        DestroySpawnedWalls();
    }

    IEnumerator WallSpawnIn ()
    {
        
        bool WallSpawned = false;
        while (!WallSpawned)
        {
            if (getWallsCount <= 10)
            {

                    SpawnMovWalls();
                                
            }
            if (getWallsCount <= 10)
            {
                SpawnOrbitWall();
            }
            

            //SpawnRotateWall();

            //SpawnStaticWalls();

            //SpawnTapWalls();

            yield return new WaitForSeconds(timeCurrentPlayerPosition);

            // destruye los muros creados cuando pase la bola.
            // cuando se van los muros vienen los nuevos.
            int getWalls = getWallsCount;
            //Debug.Log(getWalls);
            if (getWalls == 30)
            {
                WallSpawned = true;
            }

        }

    }

    private int CountWalls()
    {
        wallsCounted = GameObject.FindGameObjectsWithTag("Enemy").Length;
        // Debug.Log(wallsCounted);
        return wallsCounted;
;
    }
    
    private void DestroySpawnedWalls()
    {
        if (getWallsCount == 1)
        {
            //Debug.Log("Destroy one wall");
        }
    }

    private void SpawnMovWalls ()
    {
        float randX = Random.Range(-5f, 5f);
        Vector3 pointsToSpawnWall = new Vector3(randX, 0, currentPlayerPosition);

        Instantiate(wallsArray[0], pointsToSpawnWall, Quaternion.identity);
        //Debug.Log(wallsArray[0]);

        timeCurrentPlayerPosition = currentPlayerPosition + Random.Range(0.5f, 2f); // Posicion ahora de la bola añadimos unos segundos para el cooldown

    }

    private void SpawnOrbitWall ()
    {
        float randX = Random.Range(-5f, 5f);
        float randZ = Random.Range(5f, 10f);
        Vector3 pointsToSpawnWall = new Vector3(randX, 0, currentPlayerPosition);

        Instantiate(wallsArray[1], pointsToSpawnWall, Quaternion.identity);
        //Debug.Log(wallsArray[1]);
  
        timeCurrentPlayerPosition = currentPlayerPosition + Random.Range(0.5f, 2f);
    }

    private void SpawnRotateWall()
    {
        float randX = Random.Range(-5f, 5f); // Genera muros de izq a der
        float randZ = Random.Range(5f, 10f); 
        Vector3 pointsToSpawnWall = new Vector3(randX, 0, currentPlayerPosition);

        Instantiate(wallsArray[2], pointsToSpawnWall, Quaternion.identity);
        Debug.Log(wallsArray[2]);

        timeCurrentPlayerPosition = currentPlayerPosition * Random.Range(1f, 5f);
    }

    private void SpawnStaticWalls()
    {
        float randX = Random.Range(-10f, 10f);
        float randZ = Random.Range(5f, 10f);
        Vector3 pointsToSpawnWall = new Vector3(randX, 0, currentPlayerPosition);

       
        Instantiate(wallsArray[3], pointsToSpawnWall, Quaternion.identity);
        Debug.Log(wallsArray[3]);
        
        timeCurrentPlayerPosition = currentPlayerPosition * Random.Range(1f, 5f);
    }

    private void SpawnTapWalls()
    {
        float randX = Random.Range(-10f, 10f);
        float randZ = Random.Range(5f, 10f);
        Vector3 pointsToSpawnWall = new Vector3(randX, 0, currentPlayerPosition);

        Instantiate(wallsArray[4], pointsToSpawnWall, Quaternion.identity);
        Debug.Log(wallsArray[4]);
       
        timeCurrentPlayerPosition = currentPlayerPosition * Random.Range(1f, 5f);

    }
}
