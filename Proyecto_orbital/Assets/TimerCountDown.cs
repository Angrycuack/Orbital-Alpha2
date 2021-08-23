using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerCountDown : MonoBehaviour
{
    public float timeStart = 60;
    [SerializeField] public TMP_Text time_text;
    void Start()
    {
        time_text.text = timeStart.ToString();
    }
    void Update()
    {
        timeStart -= Time.deltaTime;
        time_text.text = Mathf.Round(timeStart).ToString();
    }
}
