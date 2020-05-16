using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoDMove : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D rb;
    public float jumpSpeed = 3.0f;

    private float currentspeed = 0.0f;
    private float distancetoGround = 0.0f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        distancetoGround = GetComponent<Collider2D>().bounds.extents.y;
    }
    bool IsGrounded()
        {
        return Physics2D.Raycast(new Vector2(transform.position.x,transform.position.y),Vector2.down, distancetoGround + 0.1f);
        // return (Mathf.Abs(rb.velocity.y) < Mathf.Epsilon)
        }

    // Update is called once per frame
    void FixedUpdate()
    {
        float currentSpeed = 0.0f;
        if (Input.GetKey(KeyCode.A))
        {
            currentSpeed -= speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            currentSpeed += speed;
        }
        rb.AddForce(new Vector2(currentSpeed * Time.deltaTime, 0.0f), ForceMode2D.Impulse);


        if (Input.GetKeyUp(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        }
    }
}
