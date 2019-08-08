using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BbsProperties : MonoBehaviour
{
    [SerializeField] private float mass = 0.002f;

    private float backspinDrag;

    private Rigidbody myRB = null;

    private Vector3 lastPos;

    private void Awake()
    {
        myRB = GetComponent<Rigidbody>();
        myRB.mass = mass;
    }

    void Start()
    {
        lastPos = transform.position; // Used to draw the debug line
        Destroy(gameObject, 3f);
    }

    private void Update()
    {
        DrawDebugLine();
    }

    private void FixedUpdate()
    {
        //Add the force made by the HopUp
        myRB.AddForce(0f, Mathf.Sqrt(myRB.velocity.magnitude) * backspinDrag * Time.fixedDeltaTime, 0f);
    }

    private void DrawDebugLine()
    {
        Debug.DrawLine(lastPos, transform.position, Color.red, 5);
        lastPos = transform.position;
    }

    public float BackspinDrag
    {
        set
        {
            backspinDrag = value;
        }
    }
}
