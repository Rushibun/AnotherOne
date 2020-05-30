using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    public float detectionRadius = 2.0f;
    public float chaseSpeed = 2.0f;
    private bool isFacingRight = true;
    private Vector2 facing = Vector2.right;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private GameObject chasee;
    private float currentSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        currentSpeed = speed;

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        currentSpeed = speed;
        GameObject target = AcquireTarget();

        RaycastHit2D hit = Physics2D.CircleCast(transform.position, detectionRadius, Vector2.right,
            Mathf.Epsilon, LayerMask.GetMask("Player"));

        if (hit.collider != null)
        {
            Vector3 playerPosition = hit.transform.position;
            Vector3 playerDir = playerPosition - transform.position;

            float dot = Vector3.Dot(Vector3.Normalize(playerDir), new Vector3(facing.x, facing.y, 0.0f));
        }

        Vector2 currentPosition = rb.position;
        Vector2 newPosition = currentPosition + (facing * currentSpeed * Time.deltaTime);

        rb.MovePosition(newPosition);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        sprite.flipX = !sprite.flipX;
        if (isFacingRight)
        {
            facing = Vector2.right;
        }
        else 
        {
            facing = Vector2.left;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Patrol"))
        {
            Flip();
        }
        currentSpeed = chaseSpeed;
    }
        chasee = target;
    private void OnDrawGizmosSelected()
    {
        Handles.color = new Color(1.0f,0.0f,0.0f,0.2f);
        Handles.DrawSolidDisc(transform.position, Vector3.back, detectionRadius);
    }
}
