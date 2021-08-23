using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapWall : MonoBehaviour
{
    //Generamos variables para saber si el objeto est� activo o no y tambi�n para desactivarlo.
    public bool active;
    public bool defaultactive;
    World_settings worldsettings;

    private BoxCollider wallCollider;
    public Material visible;
    public Material invisible;
    private BoxCollider orbitCollider;

    private void Start()
    {
        //Inicializamos la variables con el valor que queremos que tengan por defecto.
        
        wallCollider = GetComponent<BoxCollider>();
        worldsettings = FindObjectOfType<World_settings>();
        orbitCollider = GetComponent<BoxCollider>();
        active = worldsettings.generalactive;
        if (defaultactive == true)
        {
            active = !active;
        }
        if (active == true)
        {
            GetComponent<MeshRenderer>().material = visible;
            wallCollider.enabled = true;
            orbitCollider.enabled = true;
        }
        else
        {
            GetComponent<MeshRenderer>().material = invisible;
            wallCollider.enabled = false;
            orbitCollider.enabled = false;
        }
    }

    void Update()
    {
        //Cada vez que se pulsa el rat�n, se desactiva/activa la visual del objeto 
        //y su collider en funci�n del estado en el que se encuentre.
        if (Input.GetMouseButtonDown(0))
        {
            worldsettings = FindObjectOfType<World_settings>();
            active = worldsettings.generalactive;
            if (defaultactive == true)
            {
               active = !active;
            }
            if (active == true)
            {
                GetComponent<MeshRenderer>().material = visible;
                wallCollider.enabled = true;
                orbitCollider.enabled = true;
            }
            else
            {
                GetComponent<MeshRenderer>().material = invisible;
                wallCollider.enabled = false;
                orbitCollider.enabled = false;
            }    
        }
    }
}
