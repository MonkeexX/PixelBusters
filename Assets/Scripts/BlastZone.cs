using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class BlastZone : MonoBehaviour
{
    public GameObject player;
    public Transform respwanpoint;
    public HealthBar healthBar;
    public enemyDamege life;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
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
