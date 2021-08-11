using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitWall : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;
    private float speed;

    private void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }

    private void Update()
    {
        this.transform.RotateAround(target.transform.position, Vector3.up,speed * Time.deltaTime);
    }
}
