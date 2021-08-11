using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BecomeInVorVCamera : MonoBehaviour
{ 
    private void OnBecameVisible()
    {
        gameObject.SetActive(true);
    }
    private void OnBecameInvisible()
    {
        
        gameObject.SetActive(false);
    }
}
