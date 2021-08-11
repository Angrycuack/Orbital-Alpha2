using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private TMP_Text MoneyText;
    private void Start()
    {
        RefreshUI();
    }

    private void RefreshUI()
    {
        MoneyText.text = GameManager.instance.Player.premium.ToString();
    }
}
