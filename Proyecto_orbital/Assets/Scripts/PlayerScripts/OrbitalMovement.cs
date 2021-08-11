using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalMovement : MonoBehaviour
{
    [SerializeField] private Transform centralSphere;
    private static float speed;
    public float basicSpeed = 30f;
    private bool rotateUp;
    private static bool timer;
    private float countDown = 10f;
    private Vector3 direction;

    // Timer para agregar puntos cuando no se haya tocado la pantalla x tiempo
    [SerializeField]
    private float set_TimerNoTouch = 5;
    private float _Timer;
    private float prev_Timer;
    private float add_points = 10;

    // OverlapSphere Collider
    static Collider[] hitColliders;

    // Wall detectection
    


    private void Start()
    {
        centralSphere = GameObject.Find("CentralSphere").transform;
        this.gameObject.transform.SetParent(centralSphere);
        rotateUp = true;
        ReturnSpeed();
        direction = Vector3.up;

        _Timer = Time.fixedTime;
        prev_Timer = _Timer;
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _Timer = Time.fixedTime;
            TimerPressButton(_Timer);
            if (!rotateUp) { direction = Vector3.up; }
            if (rotateUp) { direction = Vector3.down; }
            rotateUp = !rotateUp;
        }

        if (timer) { countDown -= Time.deltaTime; }
        if (countDown <= 0) { ReturnSpeed(); }

        _Timer = Time.time;
    }
    private void FixedUpdate()
    {
        transform.RotateAround(centralSphere.transform.position, direction, speed * Time.deltaTime);
        // Debug.Log(speed);
        //Vector3 fwd = transform.TransformDirection(Vector3.forward);
        //if (Physics.Raycast(transform.position, fwd, 1))
        //{
        //    Collider detectedWall = GameObject.FindGameObjectWithTag("Wall").GetComponent<Collider>();
        //    if (Wall.name == detectedWall.name)

        //        Debug.Log("Detectado " + detectedWall);
        //    else
        //        Debug.LogError("Dectectado un muro");
            
          
        //}

    }
    /// <summary>
    /// Método que se encarga de aumentar o disminuar la velocidad del orbital.
    /// </summary>
    /// <param name="up_down">Indica si hay que aumentar la velocidad o parar el orbital.</param>
    public void SpeedUp(bool up_down)
    {
        if (up_down) { speed *= 3; }
        else { speed = 0; }
        timer = true;
    }
    /// <summary>
    /// Se encarga de devolver la velocidad del orbital al valor original.
    /// </summary>
    private void ReturnSpeed()
    {
        speed = basicSpeed;
        countDown = 10f;
        timer = false;
    }
    /// <summary>
    /// Método llamado cuando se toma el PowerUp Ghost y que desactiva o activa el collider.
    /// </summary>
    /// <param name="state">Activar o desactivar collider.</param>
    public void RemoveCollider(bool state)
    {
        GetComponent<SphereCollider>().enabled = state;
    }
    
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.blue;
    //    Gizmos.DrawWireSphere(transform.position, 1);
    //}
    
    /// <summary>
    /// Recoge el valor del tiempo cuando el jugador toco la pantalla
    /// </summary>
    /// <param name="gTime"></param>
    public void TimerPressButton (float gTime)
    {
        float dif_Time = gTime - prev_Timer;
        if (prev_Timer < gTime && dif_Time >= set_TimerNoTouch)
        {
            bool timeOn = true;
            while(timeOn)
            {
                Debug.Log("Time " + prev_Timer + " Pressed " + gTime + " Dif " + dif_Time);
                ScoreController.PointsNotTouchingScreen((int)Mathf.Round(add_points));
                timeOn = false;
            }
            
        }
            
            
        prev_Timer = gTime;
    }

}
