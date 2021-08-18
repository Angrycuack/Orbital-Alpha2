using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitDetector : MonoBehaviour
{

    PlayerScorer playerScorer;

    public bool wallDetected;
    int wallCount;
    
    float _Timer = 50f;
    int[] scores = {5, 10, 15};

    void Start()
    {
        playerScorer = GameObject.Find("ScoreController").GetComponent<PlayerScorer>();
        wallCount = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Orbital")
        {   
            StartCoroutine(WallScorerConditions());
            // wallDetected = true;
            // // Aparece un aviso 50 puntos
            // if(wallDetected) 
            // {
            //     wallCount++;
            //     print("50 puntos por pasar cerca de un muro");
            //     wallDetected = false;
            // }
            //     while(_Timer > 0) {
            //     _Timer -= Time.deltaTime;
            //     print("Pasa otro muro suma mas puntos");
            // playerScorer.PlayerScoreIncrementer(0, 150); 
            // wallCount = 0;
            //}
        }
    }

    IEnumerator WallScorerConditions() 
    {
        // aviso 50 puntos
        print("50 puntos");
        yield return new WaitForSeconds(1.5f);
        // cuando pase otro muro 100x1.1(110)
        print("110 puntos");
        yield return new WaitForSeconds(1.6f);
        // cuando pase otro muro 150x1.2(180)
        print("180 puntos");
        yield return new WaitForSeconds(2f);
        // cuando pase otro muro 180x1.3(234)
        print("234 puntos");

        // Faltan las condiciones cuando pase la accion en el siguiente muro
        // Al igual de los demas muros que vienen
 
    }



}
