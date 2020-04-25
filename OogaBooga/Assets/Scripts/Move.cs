using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector3 speed;
    
    // amount of degrees per second you want to turn
    public float turnspeed;

    private Rigidbody rb;
    public float jumpForce = 5.0f;
    private bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    // Vector3(x,y,z) = Vector3(0.1,0.0) gives me a vector that is 0.1 units in size
    // speed is a Vector3 
    float currentspeed = 0.0f;
    float currentTurnAmount = 0.0f;

    if (Input.GetKey(KeyCode.A))
    {
        currentTurnAmount -= turnspeed;
    }
    if (Input.GetKey(KeyCode.D))
    {
        currentTurnAmount += turnspeed;
    }
    if (Input.GetKey(KeyCode.W))
    {
        currentspeed = speed.x;
    }
    if (Input.GetKey(KeyCode.S))
    {
        currentspeed = -speed.x;
    }
    gameObject.transform.Rotate(Vector3.up, currentTurnAmount * Time.deltaTime);
    rb.AddForce(transform.forward * currentspeed * Time.deltaTime, ForceMode.Impulse);

    // && is and || is or
    if (Input.GetKeyUp(KeyCode.Space) && !isJumping)
    {
        isJumping = true;
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

    }

    rb.angularVelocity = Vector3.zero;
    }
}
