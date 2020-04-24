using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector3 speed;
    private Vector3 target = new Vector3(5.0f, 0.0f, 0.0f);

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
        transform.RotateAround(target, Vector3.up, 30 * Time.deltaTime);
    }
    if (Input.GetKey(KeyCode.D))
    {
        transform.RotateAround(target, Vector3.down, 30 * Time.deltaTime);
    }
    if (Input.GetKey(KeyCode.W))
    {
        transform.RotateAround(target, Vector3.forward, 30 * Time.deltaTime);
    }
    if (Input.GetKey(KeyCode.S))
    {
        transform.RotateAround(target, Vector3.back, 30 * Time.deltaTime);
    }
    gameObject.transform.Translate(currentspeed * Time.deltaTime);
    }
}
