using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [Header("Texto para el Score")]
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text showPointsWsText;
    [SerializeField] private TMP_Text showPointsNtText;

    [SerializeField] private GameObject showPointsWs;
    [SerializeField] private GameObject showPointsNt;

    public int playerTotalScore;
    private int current_score;
    private int playerWallScore;
    
    Transform playerDistance;
    private int player_Distance;
    private int current_distance_score;

    private float _Timer;
    private float prev_Timer;
    private float pressed_time;
    [SerializeField]
    public float set_timeNotouch = 5f;
    [SerializeField] private int add_Score_NoTouch = 5;
    [SerializeField] private int add_Score_CloseWall = 15;

    // Instanciar GameController
    GameController gameController;
    public int score_to_coins;
    private int divide_number = 5;

    // Instanciar direccion de giro
    [SerializeField]
    private Transform orbit;
    private float orbit_current_rotation;
    private float angleSoFar, angleLastPos;

    //Mensajes 
    [SerializeField] public string[] messages_Wall;

    void Start()
    {
        playerTotalScore = 0;
        playerDistance = GameObject.Find("Player").GetComponent<Transform>();
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        orbit = GetComponent<Transform>();

        current_score = 0;
        prev_Timer = 0;
        pressed_time = 0;
        current_distance_score = 0;
        angleSoFar = 0;
        angleLastPos = orbit.localEulerAngles[1];

        //print(messages_Wall[0]);
    }

    void Update()
    {
        _Timer = Time.fixedTime;


        ShowScoreText();
    }

    private void ShowScoreText()
    {


        PlayerNoTouchScreen();
        print(PlayerDistanceScore());
        playerTotalScore = PlayerDistanceScore();
        scoreText.text = playerTotalScore.ToString();
    }

    public IEnumerator ShowTextOnTimeWallScore()
    {
        showPointsWs.SetActive(true);
        yield return new WaitForSeconds(2f);
        showPointsWs.SetActive(false);
    }

    public IEnumerator ShowTextOnTimeNoTouch()
    {
        showPointsNt.SetActive(true);
        yield return new WaitForSeconds(1f);
        showPointsNt.SetActive(false);
        
        yield return new WaitForSeconds(1f);
    }
    int PlayerDistanceScore()
    {
        player_Distance = ((int)playerDistance.transform.position.z);

        if(player_Distance > current_distance_score)
        {
            current_score = current_distance_score++;
        }
        return current_score;
    }

    public void PlayerWallScore()
    {
        playerWallScore = add_Score_CloseWall;
        showPointsWsText.text = messages_Wall[0];
        StartCoroutine(ShowTextOnTimeWallScore());
    }
    void GetScoreToSum()
    {
            current_score += playerWallScore;
        
            
    }
    void PlayerNoTouchScreen()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            pressed_time = _Timer;
            
            if (prev_Timer != pressed_time && playerDistance.transform.position.z > 0)
            {
                float dif_time = pressed_time - prev_Timer;
                set_timeNotouch -= Time.deltaTime;
                if (set_timeNotouch <= dif_time)
                {
                    current_score += add_Score_NoTouch;
                    
                    showPointsWsText.text = "Has conseguido: " + add_Score_NoTouch + " puntos. Sin tocar la pantalla.";
                    StartCoroutine(ShowTextOnTimeNoTouch());
                    Debug.LogWarning(current_score);
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
        } 
        
    }
}
