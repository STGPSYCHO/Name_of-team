using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody),typeof(BoxCollider))]
public class MovePlayerJoystick : MonoBehaviour
{
    public float speed;
    public FixedJoystick fixedJoystick;
    public Rigidbody rb;

    public void FixedUpdate()
    {
        Vector3 direction = Vector3.up * fixedJoystick.Vertical*speed + Vector3.right * fixedJoystick.Horizontal*speed;
        rb.velocity = direction;
    }
}