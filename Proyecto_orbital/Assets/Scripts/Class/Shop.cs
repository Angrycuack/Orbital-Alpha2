using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Shop
{
    public int[] consumableId = {0,0,0};
    public bool[] consumablePurchase = { false, false, false };
    public bool[] resourcesPurchase = { false, false, false };
    public int[] skinId = { 0, 0, 0 };
    public bool[] skinPurchase = { false, false, false };
}
