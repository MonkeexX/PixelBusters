using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private float daño;

    private Vector2 direccionDisparo; // Almacena la dirección en la que se disparó la bala

    void Start()
    {
        // Almacenar la dirección de disparo en función de la escala X del jugador al inicio
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");

        if (enemy != null && enemy.transform.localScale.x < 0)
        {
            direccionDisparo = Vector2.right;
        }
        else
        {
            direccionDisparo = -Vector2.right;
        }
    }

    void Update()
    {
        // Mover la bala en la dirección en la que se disparó inicialmente
        transform.Translate(direccionDisparo * velocidad * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag != "Enemy")
        {
            Destroy(gameObject);
        }
    }
}