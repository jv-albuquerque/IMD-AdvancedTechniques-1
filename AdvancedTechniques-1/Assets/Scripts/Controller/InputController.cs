using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private Gun gun;

    private Vector2 axis;
    private Vector2 mouseInput;

    private MovementPlayer movementPlayer = null;

    private void Start()
    {
        movementPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // TODO: Do sothing better than get the gun like this
            if (gun == null)
                gun = GameObject.FindGameObjectWithTag("Gun").GetComponent<Gun>();
            gun.Shoot();
        }


        //MOVE THE PLAYER
        axis = new Vector2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
        mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
    }

    private void FixedUpdate()
    {
        movementPlayer.Move(axis, mouseInput);
    }
}
