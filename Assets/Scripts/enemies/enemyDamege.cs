using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamege : MonoBehaviour
{
    public int quantity = 15;
    public float maxLife = 100;
    public float actualHealth;
    public float actualLife;
    private GameObject player; // Referencia al GameObject del jugador
    public HealthBar healthBar;

    void Start()
    {
        // Buscar el GameObject del jugador al inicio
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //healthBar.ChangeActualLife(100);
        }
    }
}
