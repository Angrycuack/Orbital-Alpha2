using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGame : MonoBehaviour
{
    private void Start()
    {
        if (PlayerPrefs.HasKey("Player"))
        {
            Load();
        }
        else
        {
            GameManager.instance.Player.premium = 0;
            GameManager.instance.Player.hiScore = 0;
            GameManager.instance.Save();
        }
    }

    private void Load()
    {
        string loadGame = PlayerPrefs.GetString("Player");
        GameManager.instance.Player = JsonUtility.FromJson<Player>(loadGame);
    }
}
