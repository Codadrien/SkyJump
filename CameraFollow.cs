﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;


    void LateUpdate()
    {
        if (target.position.y+2 > transform.position.y)
        {

            Vector3 newPos = new Vector3(transform.position.x, target.position.y+2, transform.position.z);
            transform.position = newPos;
        }

    }
}
