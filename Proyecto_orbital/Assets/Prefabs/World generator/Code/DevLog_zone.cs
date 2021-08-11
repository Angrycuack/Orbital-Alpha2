using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DevLog_zone : MonoBehaviour
{
    public string codezone;
    private void Update()
    {
        GetComponent<TMPro.TextMeshProUGUI>().text = "Zone:" + codezone;
    }
}
