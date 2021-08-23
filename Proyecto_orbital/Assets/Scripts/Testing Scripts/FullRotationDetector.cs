using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullRotationDetector : MonoBehaviour
{
    Vector3 direction;

    private float orbit_prev_position;
    private float orbit_update_position;
    private float save_orbit_up_position;
    private float save_orbit_down_position;
    private float how_far_orbit_up_position;
    private float how_far_orbit_down_position;
    GameObject orbital;
    // Start is called before the first frame update
    void Start()
    {
        orbit_prev_position = this.gameObject.transform.localEulerAngles[1];
        Debug.Log(this.gameObject.name + " previous " + orbit_prev_position);
    }

    // Update is called once per frame
    void Update()
    {
        orbit_update_position = this.gameObject.transform.localEulerAngles.y;
        //Debug.Log(this.gameObject.name + " update " + orbit_update_position);
        save_orbit_up_position = this.gameObject.transform.localEulerAngles.y;
        save_orbit_down_position = this.gameObject.transform.localEulerAngles.y;
        FullRotation();
    }

    IEnumerator GetPositionOrbit()
    {
        how_far_orbit_up_position = save_orbit_up_position - orbit_update_position;

        how_far_orbit_down_position = save_orbit_down_position - orbit_update_position;
        //Debug.LogWarning("Far " + how_far_orbit_down_position);
        //Debug.LogWarning("Save "+ save_orbit_up_position);
        //Debug.LogWarning("Update " + orbit_update_position);
        yield return new WaitForSeconds(0.5f);
        if (orbit_update_position == save_orbit_up_position)
        {
            Debug.LogError("360?");
        }
        if (how_far_orbit_down_position > 0)
        {
            Debug.LogError("360 down");
        }
    }
    private void FullRotation()
    {
        if (direction == Vector3.up)
        {
            // Wait the ball in that save position
            // When the came back in that position do something.
            // Did 360 degree movement
            int startRotation = 0;
            int endRotation = ((int)save_orbit_up_position);
            startRotation = ((int)orbit_update_position);
            Debug.Log("prev " + startRotation + " save " + save_orbit_up_position + "update " + endRotation);
            if (startRotation == endRotation)
            {
                Debug.LogError(startRotation);
            }
        }
        if (direction == Vector3.down)
        {
            int startRotation = 0;
            int endRotation = ((int)orbit_update_position);
            //startRotation = ((int)orbit_update_position);
            Debug.Log("prev " + startRotation + " save " + save_orbit_up_position + "update " + endRotation);
            if (startRotation == endRotation)
            {
                Debug.LogWarning("prev " + orbit_prev_position + " save " + save_orbit_down_position + " update " + endRotation);
                Debug.Log("Necesita terminar");
            }

        }
    }
}
