using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovWall : MonoBehaviour
{
    private float minX;
    private float maxX;
    private bool direction;
    private float positionX;
    [SerializeField] private float speed;
    [SerializeField] private float actualSpeed;

    private void Start()
    {
        SetVelocity();
        direction = true;
        minX = Random.Range(-2.5f, 0);
        maxX = Random.Range(0, 2.5f);
    }

    private void Update()
    {
        positionX = transform.position.x;
        if (positionX >= maxX && direction == true) {ChangeDirection(); }
        if (positionX <= minX && direction == false) { ChangeDirection(); }
        if (positionX <= minX + 0.5f || positionX >= maxX -0.5){ ReduceVelocity();}
        else {SetVelocity(); }
    }

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(actualSpeed * Time.deltaTime, 0, 0));
    }
    /// <summary>
    /// Método que se encarga de reducir la velocidad en casos concretos.
    /// </summary>
    private void ReduceVelocity()
    {
        actualSpeed = speed / 3;
    }
    /// <summary>
    /// Método que setea la velocidad estandar del movimiento del muro.
    /// </summary>
    private void SetVelocity()
    {
        actualSpeed = speed;
    }

    private void ChangeDirection()
    {
        speed *= -1;
        direction = !direction;
    }
}
