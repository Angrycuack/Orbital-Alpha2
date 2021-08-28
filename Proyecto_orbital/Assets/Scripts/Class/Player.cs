using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player
{
    public string playerName;
    public int hiScore;
    public int premium;
    public bool powerUp;
    public string activePowerUp;
    public int speedUp;
    public int moneyUp;
    public int multiply;
    public List<int> skins;
}
