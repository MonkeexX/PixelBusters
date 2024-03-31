using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamege : MonoBehaviour
{
    public int quantity = 15;
    private GameObject player; // Referencia al GameObject del jugador

    void Start()
    {
        // Buscar el GameObject del jugador al inicio
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && player != null)
        {
            // Acceder al componente characterHealth_and_Damage y reducir la salud
            characterController playerHealth = player.GetComponent<characterController>();
            if (playerHealth != null)
            {
                playerHealth.health -= quantity;
            }
        }
    }
}
