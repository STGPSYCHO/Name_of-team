using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform Target;

    private void Update()
    {
        transform.position = Target.position - new Vector3(0,0,1);
        Debug.Log(transform.position);
    }
}
