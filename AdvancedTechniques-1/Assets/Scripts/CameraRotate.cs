using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    private enum RotationAxis
    {
        MouseX = 1,
        MouseY = 2
    }

    [SerializeField] private RotationAxis axis = RotationAxis.MouseX;

    private float minimumVert = -90f;
    private float maximumVert = 90f;

    private float sensHorizontal = 10.0f;
    private float sensVertical = 10.0f;

    private float rotationX = 0;

    void Update()
    {
        if(axis == RotationAxis.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensHorizontal, 0);
        }
        else if(axis == RotationAxis.MouseY)
        {
            rotationX -= Input.GetAxis("Mouse Y") * sensVertical;

            rotationX = Mathf.Clamp(rotationX, minimumVert, maximumVert);

            float rotationY = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
        }
    }
}
