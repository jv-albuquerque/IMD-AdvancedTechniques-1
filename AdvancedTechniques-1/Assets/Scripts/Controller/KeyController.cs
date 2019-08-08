using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    private Gun gun;
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
    }
}
