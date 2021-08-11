using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Closegame : MonoBehaviour
{
    public Button Button;


    void Start()
    {
        Button btn = Button.GetComponent<Button>();
        btn.onClick.AddListener(closegame);
    }

    public void closegame ()
    {
        Application.Quit();
    }
}
