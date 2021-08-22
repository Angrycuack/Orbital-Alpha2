using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coin : MonoBehaviour
{
    public static int playerCoins = 0;
    public int[] valueCoins = {1,5,15};
    // probando rotacion de la moneda
    //private float speedRotation = 1f;

    GameController gc_addCoins;
    PlayerScorer playerScorer;

    void Start()
    {
        gc_addCoins = FindObjectOfType<GameController>();
        playerScorer = FindObjectOfType<PlayerScorer>();
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
        // Debug.Log("El jugador ha conseguido " + playerCoins + " monedas");
        // Debug.Log("El numero es " + valueCoins + " monedas");
        gc_addCoins.AddCoins(playerCoins);
        playerScorer.PlayerCoins(playerCoins);
    }
}
