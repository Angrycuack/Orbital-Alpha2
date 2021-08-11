using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Openmenu : MonoBehaviour
{
    public Button Button;
    public GameObject menu;
    bool active;
    


    void Start()
    {
        Button btn = Button.GetComponent<Button>();
        btn.onClick.AddListener(openmenu);

    }

    public void openmenu()
    {

        active = !active;
        menu.SetActive(active);
        if (active == true)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        
    }
}
