using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private Transform groundChecker;
    public int speed = 5;
    [SerializeField] private float distance;
    public float detectionRange = 5.0f;
    private Rigidbody2D rb;
    [SerializeField] private bool m_FacingRight = true;
    private GameObject player;

    // Marcadores de inicio y final de la patrulla
    public Transform startPoint;
    public Transform endPoint;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();

        // Si los marcadores no se han asignado en el Inspector, mostrar un mensaje de advertencia
        if (startPoint == null || endPoint == null)
        {
            Debug.LogWarning("Los marcadores de inicio y final no se han asignado en el Inspector.");
        }
    }

    private void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

            if (distanceToPlayer <= detectionRange)
            {
                ChasePlayer();
            }
            else
            {
                Patrol();
            }
        }
        else
        {
            Patrol();
        }
    }

    private void Patrol()
    {
        // Mueve al enemigo hacia el siguiente punto
        Vector3 targetPoint = m_FacingRight ? endPoint.position : startPoint.position;
        Vector3 moveDirection = (targetPoint - transform.position).normalized;
        rb.velocity = new Vector2(moveDirection.x * speed, rb.velocity.y);

        // Verifica si el enemigo ha llegado lo suficientemente cerca del punto de patrulla
        if (Vector3.Distance(transform.position, targetPoint) < 0.1f && Mathf.Abs(rb.velocity.x) < 0.1f)
        {
            // Cambia de dirección
            Flip();
        }
    }

    private void ChasePlayer()
    {
        // Orientar hacia el jugador
        if (player.transform.position.x < transform.position.x && m_FacingRight)
        {
            Flip();
        }
        else if (player.transform.position.x > transform.position.x && !m_FacingRight)
        {
            Flip();
        }

        // Mover al enemigo hacia el jugador
        Vector2 moveDirection = (player.transform.position - transform.position).normalized;
        rb.velocity = new Vector2(moveDirection.x * speed, rb.velocity.y);
    }

    public void HitWall()
    {
        Flip();
    }

    private void Flip()
    {
        // Voltea al enemigo
        m_FacingRight = !m_FacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(groundChecker.transform.position, groundChecker.transform.position + Vector3.down * distance);
    }
}