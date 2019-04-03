﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour
{
    float margin = 0.001f;

    float z0 = 0f;
    float zCam;
    float wScene;
    float xL;
    float xR;

    Transform tank1;
    Transform tank2;
    // Start is called before the first frame update

    void calcScreen(Transform p1, Transform p2)
    {
        // Calculates the xL and xR screen coordinates 
        if (p1.position.x < p2.position.x)
        {
            xL = p1.position.x - margin;
            xR = p2.position.x + margin;
        }
        else
        {
            xL = p2.position.x - margin;
            xR = p1.position.x + margin;
        }
    }


    void Start()
    {
        tank1 = GameObject.FindWithTag("PlayerTank1").transform;
        tank2 = GameObject.FindWithTag("PlayerTank2").transform;

        calcScreen(tank1, tank2);
        wScene = xR - xL;
        zCam = transform.position.z - z0;

    }

    void Update()
    {
        calcScreen(tank1, tank2);
        float width = xR - xL;
        if (width > wScene)
        {
            Vector3 change = new Vector3(transform.position.x, transform.position.y, zCam * width / wScene + z0);
            transform.position = change;
        }

        Vector3 center = new Vector3((xR + xL) / 2, transform.position.y, transform.position.z);
        transform.position = center;

    }
}
