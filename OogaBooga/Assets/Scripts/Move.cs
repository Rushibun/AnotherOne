﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector3 speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Vector3(x,y,z) = Vector3(0.1,0.0) gives me a vector that is 0.1 units in size
        // speed is a Vector3 
        gameObject.transform.Translate(speed);

        if (Input.GetKey(KeyCode.A))
    {
        Vector3 position = this.transform.position;
        position.x -= 0.3f;
        this.transform.position = position;
    }
    if (Input.GetKey(KeyCode.D))
    {
        Vector3 position = this.transform.position;
        position.x += 0.3f;
        this.transform.position = position;
    }
    if (Input.GetKey(KeyCode.W))
    {
        Vector3 position = this.transform.position;
        position.z += 0.3f;
        this.transform.position = position;
    }
    if (Input.GetKey(KeyCode.S))
    {
        Vector3 position = this.transform.position;
        position.z -= 0.3f;
        this.transform.position = position;
    }
    }
}
