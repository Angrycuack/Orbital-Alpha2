using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [Header("Arrays con objetos de tienda")]
    [SerializeField] private ShopObject[] consumableObject;
    [SerializeField] private ShopObject[] inprovementObject;
    [SerializeField] private ShopObject[] skinObject;

    [Header("Arrays del panel de los consumibles")]
    [SerializeField] private Image[] spriteConsumable;
    [SerializeField] private TMP_Text[] textConsumable;
    [SerializeField] private TMP_Text[] priceConsumable;
    [SerializeField] private Button[] buttonConsumable;

    [Header("Arrays del panel de las habilidades")]
    [SerializeField] private Image[] spriteHability;
    [SerializeField] private TMP_Text[] textHability;
    [SerializeField] private TMP_Text[] priceHability;
    [SerializeField] private Button[] buttonHability;

    [Header("Arrays del panel de skins")]
    [SerializeField] private Image[] spriteSkin;
    [SerializeField] private TMP_Text[] textSkin;
    [SerializeField] private TMP_Text[] priceSkin;
    [SerializeField] private Button[] buttonSkin;

    [SerializeField] private TMP_Text MoneyText;

    //Creamos la tienda para saber si ya ha sido guardada en el día y es necesario cargarla.
    private Shop _shop = new Shop();

    private void Start()
    {
        consumableObject = Resources.LoadAll<ShopObject>("Consumibles");
        inprovementObject = Resources.LoadAll<ShopObject>("Inprovements");
        skinObject = Resources.LoadAll<ShopObject>("Skins");
        DateCheck();
        RefreshUI();
    }
    /// <summary>
    /// Refrescamos la UI en cuanto a monedas.
    /// </summary>
    private void RefreshUI()
    {
        MoneyText.text = GameManager.instance.Player.premium.ToString();
    }
    /// <summary>
    /// Checkeamos la fecha en la que se desconectó y en la que ha vuelto a conectarse.
    /// En caso de que haya pasado un día, refrescamos la tienda con nuevos artículos, en caso
    /// de que no la haya pasado, usamos los datos guardados para rellenar la tienda.
    /// </summary>
    private void DateCheck()
    {
        if(PlayerPrefs.GetString("OldDateTime") != "")
        {
            System.DateTime oldDate = System.DateTime.Parse(PlayerPrefs.GetString("OldDateTime"));
            System.TimeSpan timeDC = System.DateTime.Now - oldDate;
            if (timeDC.Days > 0) { RefreshShop(); }
            else { RefillShop(); }
        }
        else
        {
            RefreshShop();
        }
        string actualTime = System.DateTime.Now.ToString();
        PlayerPrefs.SetString("OldDateTime", actualTime);
        RefreshHability();
    }
    /// <summary>
    /// Rellenamos la tienda con nuevos artículos.
    /// </summary>
    private void RefreshShop()
    {
        //Rellenamos el panel con los objetos de la lista que están en el index dado por la variable.
        for(int i=0; i < 3; i++)
        {
            int index = i;
            int article = Random.Range(1, consumableObject.Length);
            int skin = Random.Range(1, skinObject.Length);
            textConsumable[i].text = consumableObject[article].productName;
            priceConsumable[i].text = consumableObject[article].productValue.ToString();
            spriteConsumable[i].GetComponent<Image>().sprite = consumableObject[article].productImagen;
            buttonConsumable[i].onClick.AddListener(() => Purchase(consumableObject[article],index));
            _shop.consumableId[i] = consumableObject[article].productId;
            _shop.consumablePurchase[i] = false;
            textSkin[i].text = skinObject[skin].productName;
            priceSkin[i].text = skinObject[skin].productValue.ToString();
            spriteSkin[i].GetComponent<Image>().sprite = skinObject[skin].productImagen;
            buttonSkin[i].onClick.AddListener(() => Purchase(skinObject[skin], index));
            _shop.skinId[i] = skinObject[skin].productId;
            _shop.skinPurchase[i] = false;
        }
        SaveShop();
    }
    /// <summary>
    /// Tomamos los datos guardados y rellenamos la tienda.
    /// </summary>
    private void RefillShop()
    {
        string loadShop = PlayerPrefs.GetString("Shop");
        _shop = JsonUtility.FromJson<Shop>(loadShop);
        for (int i=0; i < 3; i++)
        {
            int index = i;
            foreach(ShopObject obj in consumableObject)
            {
                if(obj.productId == _shop.consumableId[i])
                {
                    textConsumable[i].text = obj.productName;
                    priceConsumable[i].text = obj.productValue.ToString();
                    spriteConsumable[i].GetComponent<Image>().sprite = obj.productImagen;
                    buttonConsumable[i].onClick.AddListener(() => Purchase(obj, index));
                    if (_shop.consumablePurchase[index]) { buttonConsumable[index].interactable = false; }

                }
            }
            foreach (ShopObject obj in skinObject)
            {
                if(obj.productId == _shop.skinId[i])
                {
                    textSkin[i].text = obj.productName;
                    priceSkin[i].text = obj.productValue.ToString();
                    spriteSkin[i].GetComponent<Image>().sprite = obj.productImagen;
                    buttonSkin[i].onClick.AddListener(() => Purchase(obj, index));
                    if (_shop.skinPurchase[index]) { buttonSkin[index].interactable = false; }
                }
            }

        }
    }
    /// <summary>
    /// Método que se encarga de rellenar la parte de la tienda en la que van las habilidades permanentes.
    /// </summary>
    private void RefreshHability()
    {
        int indexMaxSpeed = GameManager.instance.Player.speedUp;
        int indexMaxMoney = GameManager.instance.Player.moneyUp;
        int indexMaxMultiply = GameManager.instance.Player.multiply;
        Debug.Log(indexMaxMultiply);
        foreach (ShopObject obj in inprovementObject)
        {
            if(obj.productId == indexMaxSpeed + 1 && indexMaxSpeed < 5) 
            {
                textHability[0].text = obj.productName;
                spriteHability[0].sprite = obj.productImagen;
                priceHability[0].text = obj.productValue.ToString();
                if (_shop.resourcesPurchase[0] == true) { buttonHability[0].interactable = false; }
                buttonHability[0].onClick.AddListener(() => Purchase(obj, 0));
            }
        }
        foreach (ShopObject obj in inprovementObject)
        {
            if (obj.productId == indexMaxMoney + 1 && indexMaxMoney < 15)
            {
                textHability[1].text = obj.productName;
                spriteHability[1].sprite = obj.productImagen;
                priceHability[1].text = obj.productValue.ToString();
                if (_shop.resourcesPurchase[1] == true) { buttonHability[1].interactable = false; }
                buttonHability[1].onClick.AddListener(() => Purchase(obj, 1));
            }
        }
        foreach (ShopObject obj in inprovementObject)
        {
            if(obj.productId == indexMaxMultiply + 1 && indexMaxMultiply < 25)
            {
                textHability[2].text = obj.productName;
                spriteHability[2].sprite = obj.productImagen;
                priceHability[2].text = obj.productValue.ToString();
                if (_shop.resourcesPurchase[2] == true) { buttonHability[2].interactable = false; }
                buttonHability[2].onClick.AddListener(() => Purchase(obj, 2));
            }
        }
    }
    /// <summary>
    /// Método que se encarga de comprobar si hay dinero suficiente antes de seguir con la compra.
    /// </summary>
    /// <param name="product"></param>
    private void Purchase(ShopObject product, int index)
    {
        if (GameManager.instance.Player.premium < product.productValue)
        {
            Debug.Log("No dispones de dinero suficiente");
        }
        else
        {
            GameManager.instance.Player.premium -= product.productValue;
            if (product.ProductType == ShopObject.Type.CONSUMABLE)
            {
                if (!GameManager.instance.Player.powerUp)
                {
                    Debug.Log("Compra realizada");
                    
                    GameManager.instance.Player.powerUp = true;
                    GameManager.instance.Player.activePowerUp = product.productName;
                    _shop.consumablePurchase[index] = true;
                    buttonConsumable[index].interactable = false;
                    priceConsumable[index].text = "Comprado";
                }
                else { Debug.Log("Ya tienes un power up activo"); }
            }
            if (product.ProductType == ShopObject.Type.HABILITY)
            {

                Debug.Log("Compra realizada en el: " + index);
                if (index == 0) { GameManager.instance.Player.speedUp++; }
                if (index == 1) { GameManager.instance.Player.moneyUp++; }    
                if (index == 2) { GameManager.instance.Player.multiply++; }
                _shop.resourcesPurchase[index] = true;
                buttonHability[index].interactable = false;
            }
            if (product.ProductType == ShopObject.Type.SKIN)
            {
                Debug.Log("Compra de skin realizada");
                GameManager.instance.Player.skins.Add(product.productId);
                _shop.skinPurchase[index] = true;
                buttonSkin[index].interactable = false;
            }
            GameManager.instance.Save();
            RefreshUI();
            SaveShop();
        }
    }
    

    public void AddMoney()
    {
        GameManager.instance.Player.premium += 100;
        GameManager.instance.Player.powerUp = false;
        RefreshUI();
    }
    /// <summary>
    /// Método que se encarga de salvar los cambios que se hayan producido en la tienda.
    /// </summary>
    private void SaveShop()
    {
        string saveShop = JsonUtility.ToJson(_shop);
        PlayerPrefs.SetString("Shop", saveShop);
    }
}
