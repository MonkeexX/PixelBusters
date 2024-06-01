using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Boss : MonoBehaviour
{
    [SerializeField] private Transform groundChecker;
    public int speed = 100;
    [SerializeField] private float distance;
    public float detectionRange = 40.0f;
    private Rigidbody2D rb;
    [SerializeField] private bool m_FacingRight = true;
    private GameObject player;
    private EnemyShoot enemyShoot;
    public float timeToMove = 0;
    public float timeToJump = 0;
    public float timeToFall = 0;
    float bossJumpX = 7000.0f;
    float bossJumpY = 8000.0f;
    float bossJumpY2 = 30.0f;

    public int lives = 49;

    // Marcadores de inicio y final de la patrulla
    public Transform startPoint;
    public Transform endPoint;


    public void activateShoot()
    {
        enemyShoot.Shoot();
    }
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();

        // Si los marcadores no se han asignado en el Inspector, mostrar un mensaje de advertencia
        if (startPoint == null || endPoint == null)
        {
            Debug.LogWarning("Los marcadores de inicio y final no se han asignado en el Inspector.");
        }

        // Obtener referencia al componente EnemyShoot
        enemyShoot = GetComponentInChildren<EnemyShoot>();
    }

    private void Update()
    {

        timeToMove += Time.deltaTime;
        timeToJump += Time.deltaTime;

            float distanceToPlayer = Vector2.Distance(player.transform.position, transform.position);
        Debug.Log(distanceToPlayer);

        if (distanceToPlayer <= detectionRange)
            {
                ChasePlayer();
            }
            else
            {
                //Patrol();
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

            // Deshabilitar el disparo cuando comienza la patrulla
            if (enemyShoot != null)
            {
                enemyShoot.EnableShooting(false);
            }
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

        // Habilita el disparo mientras persigue al jugador
        if (enemyShoot != null)
        {
            enemyShoot.EnableShooting(true);
        }

        // Mover al enemigo hacia el jugador
        if (timeToMove >= 12.0f)
        {
            Vector2 moveDirection = (player.transform.position - transform.position).normalized;
            rb.velocity = new Vector2(moveDirection.x * speed, rb.velocity.y);
            timeToMove = 0;
        }

        if (timeToJump >= 10.0f)
        {
            bossJumpX *= -1;
            rb.AddForce(new Vector2(bossJumpX, bossJumpY));
            timeToJump = 0;
        }

        if (lives == 25)
        {
            timeToFall += Time.deltaTime;
            

            if (timeToFall <= 22.0f)
            {
                enemyShoot.elevado = true;
                rb.AddForce(new Vector2(0.0f, bossJumpY2));
            }
        }

        if (timeToFall >= 22.0f)
        {
            bossJumpY2 *= -1;
            rb.AddForce(new Vector2(0.0f, bossJumpY2));
            enemyShoot.elevado = false;
        }
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
        if (lives > 0)
        {
            if (collision.gameObject.CompareTag("Bullet"))
            {
                lives--;
            }

        }
        else
        {
            Destroy(gameObject);
        }

    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawLine(groundChecker.transform.position, groundChecker.transform.position + Vector3.down * distance);
    //}
}
