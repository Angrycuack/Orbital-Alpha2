using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScorer : MonoBehaviour
{
    private int playerScore;
    [SerializeField] public TMP_Text playerScore_Text;
    [SerializeField] public GameObject playerScoreText_Object;

    [SerializeField] public TMP_Text msgScore_Text;
    [SerializeField] public GameObject msgScore_Object;

    [SerializeField] public int countDownTimer_TS;

    private float _Timer;
    private int setCounter;
    private float prev_time;

    GameObject playerDistance;
    Transform orbitRotation;

    private float full_rotation;
    private float set_rotation;
    //private float end_rotation = 0;

    public int score;
    public int current_score;
    public int update_score;
    public int save_score;
    public int addScore_TS = 10;

    GameController gameController;
    public int coin_divider = 100;
    public int coinsTotal;
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

        //Debug.Log(current_score);
        PlayerScorePrint();
        //playerScore_Text.text = score.ToString();
        // refresh_score

    }

    void PlayerTouchScreenScore()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(TouchedScreenScore());
        }
    }
    IEnumerator TouchedScreenScore()
    {   
        msgScore_Object.SetActive(true);
        //refresh the counter
        //hay un bug, cuenta atras mas rapido despues del tercer click
        setCounter = countDownTimer_TS;
            while(setCounter > 0)
            {
                //cuenta atras
                //msgScore_Text.text = setCounter.ToString();
                yield return new WaitForSeconds(1f);
                setCounter--;
            }
            if(setCounter == 0) {
                score = addScore_TS;
                PlayerScoreIncrementer(0, score);
                msgScore_Text.text = "You recieved " + score + " points";
                msgScore_Object.SetActive(false);
            }

        
    }


    public void PlayerScoreCoinConverter(int getScore)
    {
        if(!gameController.isGameActive)
        {
            coinsTotal  = getScore / coin_divider;
            msgScore_Object.SetActive(true);
            msgScore_Text.text = "Puntos convertidas en monedas " + coinsTotal;
        }
    }

}
