using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVehicle : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 90f;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");  // GetAxisRaw gera [-1, 0, 1]
        float vertical = Input.GetAxis("Vertical");

        if (vertical != 0f)
            transform.Translate(Vector3.forward * vertical * moveSpeed * Time.deltaTime);
        if (horizontal != 0f)
            transform.Rotate(Vector3.up, horizontal * turnSpeed * Time.deltaTime);
    }
}
