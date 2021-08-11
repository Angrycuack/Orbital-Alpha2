using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform targetPlayer;
    public Vector3 cameraPosition;

    public float smoothMode = 0.135f;

    public bool lookAtPlayer = false;
    void Start()
    {
        cameraPosition = transform.position - targetPlayer.transform.position;    
    }

    private void LateUpdate()
    {
        Vector3 newPosition = targetPlayer.transform.position + cameraPosition;
        transform.position = Vector3.Slerp(transform.position, newPosition, smoothMode);

        if (lookAtPlayer)
        {
            transform.LookAt(targetPlayer);
        }
    }

}
