using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private Transform groundChecker;
    public int speed = 5;
    [SerializeField] private float distance;
    public float detectionRange = 5.0f;
    private Rigidbody2D rb;
    [SerializeField] private bool isFacingRight = true;
    [SerializeField] private bool rightMove;

    public bool isChasing = false;
    public bool isOnPatrol;
    private GameObject player;

    private Vector3 startPoint;
    private Vector3 endPoint;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();

        startPoint = transform.position;
        endPoint = startPoint + Vector3.right * 5f; // Define un punto final para la patrulla
    }

    void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

            if (distanceToPlayer <= detectionRange)
            {
                ChasePlayer();
                isChasing = true;
                isOnPatrol = false;
            }
            else
            {
                Patrol();
                isOnPatrol = true;
                isChasing = false;
            }
        }
        else
        {
            Patrol();
            isOnPatrol = true;
            isChasing = false;
        }
    }

    void Patrol()
    {
        if (transform.position.x >= endPoint.x)
        {
            isFacingRight = false;
        }
        else if (transform.position.x <= startPoint.x)
        {
            isFacingRight = true;
        }

        if (isFacingRight)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
    }

    void ChasePlayer()
    {
        if (isOnPatrol == false && isChasing == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Muro"))
        {
            Flip();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(groundChecker.transform.position, groundChecker.transform.position + Vector3.down * distance);
    }
}