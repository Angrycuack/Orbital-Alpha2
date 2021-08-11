using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetector : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Wall detected " + collision.gameObject.name);
            int addTo_playerScore = 10;
            ScoreController.PointsWhenOrbitClosetoWall(addTo_playerScore);
        }
    }
}
