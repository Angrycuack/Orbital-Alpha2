using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private Player _player = new Player();
    private Options _options = new Options();
    public Player Player { get { return _player; } set { _player = value; } }
    public Options Options { get { return _options; } set { _options = value; } }

    private void Awake()
    {
        instance = this;
        QualitySettings.vSyncCount = 3 ;
        Resolution playerScreen = Screen.currentResolution;
        if(playerScreen.refreshRate > 60)
        {
            Application.targetFrameRate = 60;
        }
        else
        {
            Application.targetFrameRate = 30;
        }
    }

    public void Save()
    {
        string saveGame = JsonUtility.ToJson(Player);
        PlayerPrefs.SetString("Player", saveGame);
        string saveOptions = JsonUtility.ToJson(Options);
        PlayerPrefs.SetString("Options", saveOptions);
    }

}
