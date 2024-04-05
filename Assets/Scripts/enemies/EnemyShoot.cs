using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Transform controladorDisparo;
    public GameObject bullet;
    public float intervaloDisparo = 5.0f; // Intervalo entre disparos en segundos
    private float tiempoUltimoDisparo; // Tiempo del último disparo
    private bool canShoot = true; // Variable para controlar si el enemigo puede disparar

    void Start()
    {
        tiempoUltimoDisparo = Time.time;
    }

    void Update()
    {
        if (canShoot && Time.time - tiempoUltimoDisparo >= intervaloDisparo)
        {
            tiempoUltimoDisparo = Time.time;
            Shoot();
        }
    }

    public void Shoot()
    {
        GameObject newBullet = Instantiate(bullet, controladorDisparo.position, controladorDisparo.rotation);
        Destroy(newBullet.gameObject, 1.0f); // Destruir la bala después de 1 segundo
    }

    // Método para habilitar o deshabilitar el disparo
    public void EnableShooting(bool enable)
    {
        canShoot = enable;
    }
}