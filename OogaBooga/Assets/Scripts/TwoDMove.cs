using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoDMove : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D rb;
    public float jumpForce = 10.0f;

    private float currentspeed = 0.0f;
    private float distancetoGround = 0.0f;
    private int jumpCount = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        distancetoGround = GetComponent<Collider2D>().bounds.extents.y;
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

        bool IsGrounded()
    {
        return Physics.Raycast(transform.position,Vector2.down, distancetoGround + 0.1f);
        // return (Mathf.Abs(rb.velocity.y) < Mathf.Epsilon)
    }
        bool isGrounded = IsGrounded();

        if (isGrounded)
        {
            jumpCount = 0;

        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
