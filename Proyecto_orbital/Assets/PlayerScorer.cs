using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScorer : MonoBehaviour
{
    
    [SerializeField] public TMP_Text playerScore_Text;
    [SerializeField] public GameObject playerScoreText_Object;

    [SerializeField] public TMP_Text msgScore_Text;
    [SerializeField] public GameObject msgScore_Object;
    [Header ("Set the time touch screen (float)")]
    [SerializeField] public float setTouchScreenTimer;
    [Header ("Set the score touch screen")]
    public int addScore_TS;

    private float _Timer;
    private float setCounter;
    private float prev_time;

    GameObject playerDistance;
    Transform orbitRotation;

    private float full_rotation;
    private float set_rotation;
    //private float end_rotation = 0;

    [Header ("Total Player Score Stat")]
    public int playerScore;
    public int current_score;
    public int update_score;
    public int save_score;
    [Header ("Incrementer Points Stats")]
    public int _touchScreenPoints;
    public int _fullRotationPoints;
    public int _nearWallPoints;
    public int _distancePoints;

    [Header ("Coin Stat")]
    GameController gameController;
    public int coin_divider = 100;
    public int coinsTotal;
    public int current_Coins;

    void Start()
    {
        playerDistance = GameObject.FindGameObjectWithTag("Player");
        gameController = FindObjectOfType<GameController>();
        playerScore = 0;
        save_score = 0;
    }

    void Update()
    {
        _Timer = Time.deltaTime;
        PlayerScorePrint();
        PlayerTouchScreenScore();
    }

    public void PlayerScorePrint() 
    {
        current_score = save_score + update_score;
        playerScore = current_score;
        PlayerScoreCoinConverter(playerScore);
        //Debug.LogWarning("playerScore " + playerScore + " current_score " + current_score + " update_score " + update_score);
        playerScore_Text.text = playerScore.ToString();
        
    }

    public void PlayerScoreIncrementer(int increaseScore, int addedScore)
    {
        if(addedScore != 0) {
            save_score += addedScore;
        }
        //Debug.LogError(save_score);
        update_score = increaseScore;
        //save for stats
        _distancePoints = increaseScore;

        //Debug.Log(current_score);
        PlayerScorePrint();
        //playerScore_Text.text = score.ToString();
        // refresh_score

    }

    void PlayerTouchScreenScore()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float _timer = setTouchScreenTimer;
            StartCoroutine(TouchedScreenScore(_timer));
        }
    }
    IEnumerator TouchedScreenScore(float _timer)
    {   Debug.LogError(_timer);
        msgScore_Object.SetActive(true);
        msgScore_Object.SetActive(false);
        yield return new WaitForSeconds(_timer);
        msgScore_Object.SetActive(true);
        Debug.LogError(_timer);
        PlayerScoreIncrementer(0, addScore_TS);
        //save to stats
        _touchScreenPoints += addScore_TS;
        msgScore_Text.text = "You recieved " + addScore_TS + " points";
        msgScore_Object.SetActive(false);
        

    }

    public void PlayerNearWallScore (int getscore) 
    {
        _nearWallPoints += getscore;
        PlayerScoreIncrementer(0, _nearWallPoints);
    }
    public void PlayerFullRotationScore(int getscore)
    {
        _fullRotationPoints += getscore;
        PlayerScoreIncrementer(0,_fullRotationPoints);

    }


    public void PlayerScoreCoinConverter(int getScore)
    {
        if(!gameController.isGameActive)
        {
            coinsTotal  = getScore / coin_divider;
            msgScore_Object.SetActive(true);
            msgScore_Text.text = "Monedas obtenidas: " + current_Coins + "\nPuntos convertidas en monedas " + coinsTotal;
        }
    }

    public void PlayerCoins(int getcoins) {
        current_Coins += getcoins;
    }

    public void PlayerScoreDisplay(string score) 
    {
        msgScore_Object.SetActive(true);
        msgScore_Text.text = "Pasa cerca del muro, te llevas " + score + " puntos";
        msgScore_Object.SetActive(false);
    }

}
