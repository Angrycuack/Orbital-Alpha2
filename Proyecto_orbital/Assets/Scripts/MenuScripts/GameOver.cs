using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField]private Button continueB_Button;
    [SerializeField] private Image continueB_Image;
    [SerializeField] private Text continue_Text;
    private void Update()
    {
        if (this.gameObject.activeInHierarchy)
        {
            RefreshButton();
        }
    }
    public void RefreshButton()
    {
        if (GameController.instance.continueButton)
        {
            continueB_Button.interactable = true;
            continueB_Image.color = new Color(0.039f, 1f, 1f, 1);
            continue_Text.text = "Remaining: 1";
        }
        else
        {
            continueB_Button.interactable = false;
            continueB_Image.color = new Color(1f, 1f, 1f, 1);
            continue_Text.text = "No remaining.";
        }
    }
}
