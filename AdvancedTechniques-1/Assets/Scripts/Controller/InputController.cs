using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private Gun gun;

    private Vector2 axis;

    private MovementPlayer movementPlayer = null;

    private void Start()
    {
        movementPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the left button of the mouse to call shoot function
        if (Input.GetMouseButtonDown(0))
        {
            // TODO: Do sothing better than get the gun like this
            if (gun == null)
                gun = GameObject.FindGameObjectWithTag("Gun").GetComponent<Gun>();
            gun.Shoot();
        }


        if (Input.mouseScrollDelta.y != 0)
            gun.SetHopUp = Input.mouseScrollDelta.y;


        //Get the value of the axis to use to move the player
        axis = new Vector2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
    }

    private void FixedUpdate()
    {
        movementPlayer.Move(axis);
    }
}
