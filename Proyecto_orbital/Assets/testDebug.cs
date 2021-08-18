using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class testDebug : MonoBehaviour
{
    List<GameObject> GetNonSceneObjects()
    {
        List<GameObject> objectsInScene = new List<GameObject>();

        foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
        {
            if (EditorUtility.IsPersistent(go.transform.root.gameObject) && !(go.hideFlags == HideFlags.NotEditable || go.hideFlags == HideFlags.HideAndDontSave))
                objectsInScene.Add(go);
        }

        return objectsInScene;
    }

    // Update is called once per frame
    void Start()
    {

        foreach (GameObject objeto in GetNonSceneObjects())
        {
            print(objeto);
        }
    }
}
