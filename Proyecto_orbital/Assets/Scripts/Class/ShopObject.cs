using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="Object/ShopObject", fileName = "ShopObject.asset")]
public class ShopObject : ScriptableObject
{
    public enum Type { CONSUMABLE,HABILITY,SKIN};
    public Type ProductType;
    public int productId;
    public Sprite productImagen;
    public string productName;
    public int productValue;
}
