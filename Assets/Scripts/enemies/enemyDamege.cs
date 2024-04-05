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

    void Start()
    {
        // Buscar el GameObject del jugador al inicio
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && player != null)
        {
            // Acceder al componente characterHealth_and_Damage y reducir la salud
            Combat playerHealth = player.GetComponent<Combat>();
            if (playerHealth != null)
            {
                playerHealth.vida -= quantity;
            }
        }
    }
}
