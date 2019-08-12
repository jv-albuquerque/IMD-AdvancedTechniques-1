using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    [SerializeField] private float speed = 10;


    public void Move(Vector2 axis)
    {
        axis *= speed * Time.fixedDeltaTime;

        transform.position += transform.forward * axis.x + transform.right * axis.y;
    }
}
