using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Coin : MonoBehaviour
{
    public static int playerCoins = 0;
    public int[] valueCoins = {1,5,15};
    // probando rotacion de la moneda
    //private float speedRotation = 1f;

    //Instanciar GameController
    GameController gc_addCoins;

    void Start()
    {
        gc_addCoins = GameObject.FindObjectOfType<GameController>();
    }
    void Update()
    {

            //transform.RotateAround(this.transform.position, Vector3.up, speedRotation * Time.deltaTime);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Orbital"))
        {
            PickedPlayerCoin();

            Destroy(gameObject);
            
        }

    }
    public void PickedPlayerCoin()
    {
        int coinNum = Random.Range(0, 2);
        playerCoins = valueCoins[coinNum];
        //Debug.Log("El jugador ha conseguido " + playerCoins + " monedas");
        //Debug.Log("El numero es " + valueCoins + " monedas");
        gc_addCoins.AddCoins(playerCoins);
    }
}
