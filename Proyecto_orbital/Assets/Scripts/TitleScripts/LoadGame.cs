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
            GameManager.instance.Options.generalVolumen = 100;
            GameManager.instance.Options.musicVolumen = 100;
            GameManager.instance.Options.sFXVolumen = 100;
            GameManager.instance.Save();
        }
    }

    private void Load()
    {
        string loadGame = PlayerPrefs.GetString("Player");
        GameManager.instance.Player = JsonUtility.FromJson<Player>(loadGame);
        string loadOptions = PlayerPrefs.GetString("Options");
        GameManager.instance.Options = JsonUtility.FromJson<Options>(loadOptions);
    }
}
