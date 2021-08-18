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

    private float _Timer;
    [SerializeField] public int countDownTimer_TS;
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
    void Start()
    {
        playerDistance = GameObject.FindGameObjectWithTag("Player");
        
        playerScore = 0;
        save_score = 0;
    }

    void Update()
    {
        _Timer = Time.deltaTime;
        PlayerScorePrint();
        PlayerTouchScreenScore();
    }

    // void UpdatePlayerScoreUI()
    // {
    //     playerScore = current_score + update_score_1;
    //     playerScore_Text.text = playerScore.ToString();
    // }


    public void PlayerScorePrint() 
    {
        current_score = save_score + update_score;
        playerScore = current_score;
        //Debug.LogWarning("playerScore " + playerScore + " current_score " + current_score + " update_score " + update_score);
        playerScore_Text.text = playerScore.ToString();
        
    }

    public void PlayerScoreIncrementer(int increaseScore, int addedScore)
    {
        if(addedScore != null) {
            save_score += addedScore;
        }
        Debug.LogError(save_score);
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
            setCounter = countDownTimer_TS;
            msgScore_Object.SetActive(true);
            StartCoroutine(TouchScreenTimer());
        }
    }
    IEnumerator TouchScreenTimer()
    {
        while(setCounter > 0)
        {
            msgScore_Text.text = setCounter.ToString();
            yield return new WaitForSeconds(1f);
            setCounter--;
        }
        int addScore = countDownTimer_TS;
        msgScore_Text.text = "You recieved " + addScore+ " points";
        update_score = addScore;
        PlayerScoreIncrementer(0, update_score);
        yield return new WaitForSeconds(1f);
        msgScore_Object.SetActive(false);
    }


    public void PlayerWallScorer(int addScore)
    {
        // score += addScore;
        // playerScore_Text.text = score.ToString();
    }

}
