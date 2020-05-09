using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 2DMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5;
    private Rigidbody2D rb;
    public float jumpForce = 10.0f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
    }
}
