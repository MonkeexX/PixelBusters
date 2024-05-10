using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BlastZone : MonoBehaviour
{
    public GameObject player;
    public Transform respwanpoint;
    public HealthBar healthBar;
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.transform.position = respwanpoint.position;
            healthBar.ChangeActualLife(20);

        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }
}
