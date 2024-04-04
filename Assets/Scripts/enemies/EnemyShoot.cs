using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Transform controladorDisparo;
    public GameObject bullet;
    public float intervaloDisparo = 5.0f; // Intervalo entre disparos en segundos
    private float tiempoUltimoDisparo; // Tiempo del último disparo
    private Transform player; // Referencia al transform del jugador

    void Start()
    {
        tiempoUltimoDisparo = Time.time;
        player = GameObject.FindGameObjectWithTag("Player").transform; // Encuentra el transform del jugador
    }

    void Update()
    {
        if (Time.time - tiempoUltimoDisparo >= intervaloDisparo)
        {
            Shoot();
            tiempoUltimoDisparo = Time.time;
        }
    }

    private void Shoot()
    {
        GameObject newBullet = Instantiate(bullet, controladorDisparo.position, controladorDisparo.rotation);
        Destroy(newBullet.gameObject, 1.0f); // Destruir la bala después de 1 segundo
    }
}