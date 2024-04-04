using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muroGiro : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyScript enemyScript = collision.gameObject.GetComponent<enemyScript>();
            if (enemyScript != null)
            {
                enemyScript.HitWall();
            }
        }
    }
}
