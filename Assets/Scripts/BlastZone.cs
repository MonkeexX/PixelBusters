using System.Collections;
using System.Collections.Generic;
//using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.UIElements;

public class BlastZone : MonoBehaviour
{
    public GameObject player;
    public Transform respwanpoint;
    public HealthBar healthBar;
    public cameraShake cameraShake;
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.transform.position = respwanpoint.position;
            healthBar.ChangeActualLife(20);
            cameraShake.ShakeCamera();
            cameraShake.timer = 0.5f;

        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }

        if (cameraShake.timer > 0)
        {
            cameraShake.timer -= Time.deltaTime;
            if (cameraShake.timer < 0)
            {
                cameraShake.StopShake();
            }
        }
    }
}
