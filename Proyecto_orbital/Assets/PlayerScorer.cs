using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScorer : MonoBehaviour
{
    
    [SerializeField] public TMP_Text playerScore_Text;
    [SerializeField] public GameObject playerScoreText_Object;
    GameController gameController;

    [SerializeField] public TMP_Text msgScore_Text;
    [SerializeField] public GameObject msgScore_Object;

    [Header ("Touch Screen Config")]
    [SerializeField] public float setTouchScreenTimer;
    public int addScore_TS;
    public bool timerIntRunning = false;
    public float _statTimer;

    GameObject playerDistance;
    Transform orbitRotation;

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

    public int coin_divider = 100;
    public int convertedCoins;
    public int current_Coins;
    public int totalCoins;

    void Start()
    {
        playerDistance = GameObject.FindGameObjectWithTag("Player");
        gameController = FindObjectOfType<GameController>();
        playerScore = 0;
        save_score = 0;
        totalCoins = 0;
    }

    void Update()
    {

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
            if(setTouchScreenTimer >= 0 && timerIntRunning)
            {
                _statTimer = 0;
            }
            timerIntRunning = true;
            _statTimer = 0;
            

            
            
        }
        if(timerIntRunning)
        {
            if(_statTimer < setTouchScreenTimer)
            {
                _statTimer += Time.deltaTime;
            }
            else
            {
                PlayerScoreIncrementer(0, addScore_TS);
                //save to stats
                _touchScreenPoints += addScore_TS;
                msgScore_Text.text = "You recieved " + addScore_TS + " points";
                StartCoroutine(DisplayScoreScreen());
                _statTimer = 0;
                timerIntRunning = false;
            }
        }
    }
    IEnumerator DisplayScoreScreen()
    {  
        msgScore_Object.SetActive(true);
        yield return new WaitForSeconds(1f);
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
            convertedCoins  = getScore / coin_divider;
            totalCoins = current_Coins + convertedCoins;
            msgScore_Object.SetActive(true);
            msgScore_Text.text = "Monedas obtenidas: " + current_Coins + "\nPuntos convertidas en monedas " + convertedCoins + "\n Total monedas: " + totalCoins;
        }
    }

    public void PlayerCoins(int getcoins) {
        current_Coins += getcoins;
    }

    public void PlayerScoreDisplay(string score) 
    {
        
        msgScore_Text.text = "Pasa cerca del muro, te llevas " + score + " puntos";
        StartCoroutine(DisplayScoreScreen());
    }

}
