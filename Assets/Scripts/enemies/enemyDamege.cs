using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class enemyDamege : MonoBehaviour
{
    [SerializeField] private ParticleSystem damageParticle;
    public int quantity = 15;
    public float maxLife = 100;
    public float actualHealth;
    public float actualLife;
    private GameObject player; // Referencia al GameObject del jugador
    public HealthBar healthBar;
    private ParticleSystem damageParticleInstance;

    void Start()
    {
        // Buscar el GameObject del jugador al inicio
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
          
            damageParticleInstance = Instantiate(damageParticle, transform.position, Quaternion.identity);
            //healthBar.ChangeActualLife(100);
        }
    }


}
