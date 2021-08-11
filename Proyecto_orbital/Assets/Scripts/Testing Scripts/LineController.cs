using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    private LineRenderer lineRenderer;

    // animacion
    [SerializeField]
    private float animationDuration = 5f;


    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        


        StartCoroutine(AnimateTheLine());

    }
    void Update()
    {

    }

    private IEnumerator AnimateTheLine()
    {
        float startTime = Time.time;

        Vector3 startPosition = lineRenderer.GetPosition(0);
        Vector3 endPosition = lineRenderer.GetPosition(1);

        Vector3 pos = startPosition;
        while(pos != endPosition)
        {
            float t = (Time.time - startTime) / animationDuration;
            pos = Vector3.Lerp(startPosition, endPosition, t);
            yield return null;
        }
    }

        
}
