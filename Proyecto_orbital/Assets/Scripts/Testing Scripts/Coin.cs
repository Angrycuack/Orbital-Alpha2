using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Coin : MonoBehaviour
{
    public static int playerCoins = 0;
    public int[] valueCoins = {1,5,15};

    [SerializeField] private TMP_Text coinText;


    private float speedRotation = 1f;

    void Update()
    {

            transform.Rotate(Vector3.back * speedRotation * Time.deltaTime);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Orbital"))
        {
            PickedPlayerCoin();

            Destroy(gameObject);
            
        }

    }

    IEnumerator ShowTextCoin ()
    {
        coinText.text = Coin.playerCoins.ToString();
        yield return  new WaitForSeconds(2f);
    }
    public void PickedPlayerCoin()
    {
        int coinNum = Random.Range(0, 2);
        playerCoins = valueCoins[coinNum];
        Debug.Log("El jugador ha conseguido " + playerCoins + " monedas");
        Debug.Log("El numero es " + valueCoins + " monedas");
    }

    public static int ConvertPointsToCoins (int pScore)
    {
        int sc = pScore / 100;
        return playerCoins =+ sc;
    }

}
