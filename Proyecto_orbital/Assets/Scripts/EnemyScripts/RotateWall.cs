using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWall : MonoBehaviour
{
    //Creamos una variable para la velocidad mínima, la máxima, y la generada aleatoriamente.
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;
    private float finalSpeed;

    private void Start()
    {
        finalSpeed = Random.Range(minSpeed, maxSpeed);
    }
    private void Update()
    {
        transform.Rotate(Vector3.up * finalSpeed * Time.deltaTime);
    }
}
