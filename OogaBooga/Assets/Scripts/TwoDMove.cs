using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TwoDMove : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D rb;
    public float jumpSpeed = 3.0f;

    private float currentspeed = 0.0f;
    private float distancetoGround = 0.0f;
    private bool isJumping = false;
    private LayerMask mask;
    public float points = 0;


    void Start()
    {
        int maskValue = LayerMask.GetMask("Player");
        mask = ~maskValue;
        isJumping = false;
        rb = GetComponent<Rigidbody2D>();
        distancetoGround = GetComponent<CircleCollider2D>().radius + Mathf.Epsilon;
    }
    bool IsGrounded()
        {
        //Cast a ray from the bottom of the player collider to 0.1 units to find a collider.  
        //Searching in every layer but the layer that belongs to the player
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - distancetoGround), Vector2.down, 0.1f, mask);

        //If the collider isn't null that means we hit something.  We are grounded.
        return (hit.collider != null);
        }

    // Update is called once per frame
    private void Update()
    {
        //If I hit space key and I'm grounded I'm jumping
        if(Input.GetKeyUp(KeyCode.Space) && IsGrounded())
        {
            isJumping = true;
        }
    }
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

        //If I'm jumping add the force.
        if (isJumping)
        {
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            isJumping = false;   //Immediately stop jumping
    }
    // if player touches pickup, it get points but... how to use TMPro??
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            points += 5;
            TMPro.TMP_Text.text("Score") += 5; // what am i doing??
        }

    }
}
}
