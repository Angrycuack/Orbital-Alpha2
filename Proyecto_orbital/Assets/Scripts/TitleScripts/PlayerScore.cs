using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [Header("Texto para el Score")]
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text showPointsText;
    [SerializeField] private GameObject showPoints;
    public int playerTotalScore;
    private int current_score;
    private int playerWallScore;
    
    PlayerMoves playerDistance;


    private float _Timer;
    private float prev_Timer;
    private float pressed_time;
    [SerializeField]
    public float set_timeNotouch = 5f;
    public int add_Score = 5;

    // Instanciar GameController
    GameController gameController;
    public int score_to_coins;
    private int divide_number = 5;

    void Start()
    {
        playerTotalScore = 0;
        playerDistance = GameObject.Find("Player").GetComponent<PlayerMoves>();
        gameController = GameObject.Find("GameController").GetComponent<GameController>();

        prev_Timer = 0;
        pressed_time = 0;
    }

    void Update()
    {
        _Timer = Time.fixedTime;
        PlayerDistanceScore();
        PlayerWallShowScore();
        PlayerNoTouchScreen();
        PlayerScoreCoinConverter();
        //Debug.Log("current score " + current_score);
        if(playerWallScore != 0)
        {
            current_score += playerWallScore;
            //Debug.LogError("score to add " + playerWallScore + " total " + current_score);
        }
        playerTotalScore = current_score;
        scoreText.text = playerTotalScore.ToString();
    }

    IEnumerator ShowTextOnTime()
    {
        showPoints.SetActive(true);
        yield return new WaitForSeconds(5f);
        showPoints.SetActive(false);
    }
    void PlayerDistanceScore()
    {
        current_score = playerDistance.playerScore;
    }

    public int PlayerWallAddScore(int getScore)
    {
        playerWallScore = getScore;
        return playerWallScore;
    }

    public void PlayerWallShowScore()
    {
        if(playerWallScore != 0)
        {
            showPointsText.text = "Has pasar cerca de un muro: " + playerWallScore + " puntos.";
            StartCoroutine(ShowTextOnTime());
        }
        
    }
    void PlayerNoTouchScreen()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            pressed_time = _Timer;
            
            if (prev_Timer != pressed_time && playerDistance.playerScore > 0)
            {
                float dif_time = pressed_time - prev_Timer;
                //Debug.LogWarning("pressed time " + pressed_time + " current time " + prev_Timer + " diff " + dif_time);
                if (dif_time >= set_timeNotouch)
                {
                    int p_score = current_score + add_Score;
                    //Debug.LogError("pressed" + p_score + " current " + current_score);
                    current_score += p_score;
                    showPointsText.text = "Has conseguido: " + add_Score + " puntos. Sin tocar la pantalla.";
                    StartCoroutine(ShowTextOnTime());
                }
            }
            prev_Timer = _Timer;
            
        }
    }

    public void PlayerScoreCoinConverter()
    {
        if (!gameController.isGameActive)
        {
            
            score_to_coins = playerTotalScore / divide_number;
            //Debug.LogWarning("Game is over " + score_to_coins);

        } 
        
    }
}
