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

    [Header ("Near Wall Scorer")]
    public static int level;
    private float timer;
    private float timerCountdown;
    private bool timeDown;

    void Start()
    {
        playerDistance = GameObject.FindGameObjectWithTag("Player");
        gameController = FindObjectOfType<GameController>();
        playerScore = 0;
        save_score = 0;
        current_score = 0;

        level = 0;
        timeDown = false;
    }

    void Update()
    {

     PlayerTouchScreenIncrementer();

     if(timeDown) {timerCountdown -= Time.deltaTime;}
     if(timerCountdown <= 0)
     {
         level = 0;
         timeDown = false;
     }
    }

    public void PlayerScorePrint(int gscore) 
    {
        
        playerScore = gscore;
        PlayerScoreCoinConverter(playerScore);
        //Debug.LogWarning("playerScore " + playerScore + " current_score " + current_score + " update_score " + update_score);
        playerScore_Text.text = playerScore.ToString();
        
    }

    public void PlayerScoreIncrementer(int increaseScore, int addedScore)
    {
        if(addedScore > 0) {
            save_score += addedScore;
        }

        update_score = increaseScore;
     
        _distancePoints = increaseScore;
        current_score = update_score;
        
        current_score = save_score + update_score;
        PlayerScorePrint(current_score);
    }

    void PlayerTouchScreenIncrementer()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(!timerIntRunning)
            {
                timerIntRunning = true;
                _statTimer = 0;
            }
            else
            {
                timerIntRunning = true;
                _statTimer = 0;
            }
            
        }
        
        TimerTouchScreenScore();
    }
    void TimerTouchScreenScore ()
    {
        if(timerIntRunning)
        {
            if(_statTimer < setTouchScreenTimer)
            {
                _statTimer += Time.deltaTime;
            }
            else
            {
                //save to stats
                PlayerTouchScreenScore(addScore_TS);
                msgScore_Text.text = "You recieved " + addScore_TS + " points";
                StartCoroutine(PlayerScoreDisplay());
                _statTimer = 0;
                timerIntRunning = false;
            }
        }
    }

    public void PlayerNearWallScore (int getscore) 
    {
        int score_to_add = getscore;
        _nearWallPoints += getscore;
        PlayerScoreIncrementer(0, score_to_add);
    }
    
    public void PlayerFullRotationScore(int getscore)
    {
        _fullRotationPoints += getscore;
        PlayerScoreIncrementer(0,_fullRotationPoints);
    }

    void PlayerTouchScreenScore (int getscore)
    {
        int score_to_add = getscore;
        _touchScreenPoints += score_to_add;
        PlayerScoreIncrementer(0, score_to_add);
    }

    public void OrbitNearWall() 
    {
        level ++;
        OrbitCombo();
    }

    private void OrbitCombo()
    {
        switch (level)
        {
            case 1:
                msgScore_Text.text = "Combo activado, sumaras 50 puntos";
                StartCoroutine(PlayerScoreDisplay());
                PlayerNearWallScore(20);
                timer = 6f;
                break;
            case 2:
                msgScore_Text.text = "sumaras 110 puntos";
                StartCoroutine(PlayerScoreDisplay());
                PlayerNearWallScore(50);
                timer = 5f;
                break;
            case 3:
                msgScore_Text.text = "sumaras 180 puntos";
                StartCoroutine(PlayerScoreDisplay());
                PlayerNearWallScore(110);
                timer = 4f;
                break;
            case 4:
                msgScore_Text.text = "sumaras 234 puntos";
                StartCoroutine(PlayerScoreDisplay());
                PlayerNearWallScore(180);
                timer = 3f;
                break;
            case 5:
                msgScore_Text.text = "sumaras 327 puntos";
                StartCoroutine(PlayerScoreDisplay());
                PlayerNearWallScore(234);
                timer = 2f;
                break;
            case 6:
                msgScore_Text.text = "sumaras 500 puntos";
                StartCoroutine(PlayerScoreDisplay());
                PlayerNearWallScore(327);
                timer = 1f;
                break;
            case 7:
                msgScore_Text.text = "Fin del Combo";
                StartCoroutine(PlayerScoreDisplay());
                break;
        }
        timerCountdown = timer;
        timeDown = true;
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

    IEnumerator PlayerScoreDisplay() 
    {
        msgScore_Object.SetActive(true);
        yield return new WaitForSeconds(1f);
        msgScore_Object.SetActive(false);
    }

}
