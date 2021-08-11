using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World_settings : MonoBehaviour
{
    public int dificulty;
    public int exp;
    public int score;

    public bool generalactive ;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            generalactive = !generalactive;
        }
        if (exp >= 100)
        {
            exp = 0;
            dificulty++;
        }
    }
}
