using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muroGiro : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyScript enemyScript = collision.gameObject.GetComponent<EnemyScript>();
            if (enemyScript != null)
            {
                enemyScript.HitWall();
            }
        }
    }
}
