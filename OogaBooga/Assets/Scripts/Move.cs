using System.Collections;
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
        Vector3 currentspeed = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
    {
        currentspeed.x = -speed.x;
    }
    if (Input.GetKey(KeyCode.D))
    {
        currentspeed.x = speed.x;
    }
    if (Input.GetKey(KeyCode.W))
    {
        currentspeed.z = -speed.z;
    }
    if (Input.GetKey(KeyCode.S))
    {
        currentspeed.z = speed.z;
    }
    gameObject.transform.Translate(currentspeed * Time.deltaTime);
    }
}
