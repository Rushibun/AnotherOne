using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletSpawnpoint;
    public Vector3 speed;
    
    // amount of degrees per second you want to turn
    public float turnspeed;
    public float jumpForce = 10.0f;
    
    private bool isJumping = false;
    private float currentspeed = 0.0f;
    private float distancetoGround = 0.0f;
    private int jumpCount = 0;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        distancetoGround = GetComponent<Collider>().bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
    // Vector3(x,y,z) = Vector3(0.1,0.0) gives me a vector that is 0.1 units in size
    // speed is a Vector3 
    currentspeed = 0.0f;
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
    if (Input.GetKey(KeyCode.F))
    {
        GameObject newBullet = GameObject.Instantiate(bullet, bulletSpawnpoint.position, new Quaternion());
        Rigidbody bulletBody = newBullet.GetComponent<Rigidbody>();
        bulletBody.AddForce(transform.forward * 30, ForceMode.Impulse);
    }
    gameObject.transform.Rotate(Vector3.up, currentTurnAmount * Time.deltaTime);

    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position,Vector3.down, distancetoGround + 0.1f);
        // return (Mathf.Abs(rb.velocity.y) < Mathf.Epsilon)
    }

    // && is and || is or
    void FixedUpdate()
    {
        rb.AddForce(transform.forward * currentspeed * Time.deltaTime, ForceMode.Impulse); 
        
        bool isGrounded = IsGrounded();

        if (isGrounded)
        {
            jumpCount = 0;

        }

        if (Input.GetKeyUp(KeyCode.Space) && (isGrounded || jumpCount < 2))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpCount ++;
        }
     rb.angularVelocity = Vector3.zero;
        
    }
}
