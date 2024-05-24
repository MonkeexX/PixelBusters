using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Transform controladorDisparo;
    public GameObject bullet;
    public float intervaloDisparo = 3.0f; // Intervalo entre disparos en segundos
    private float tiempoUltimoDisparo = 0.0f; // Tiempo del �ltimo disparo
    private bool canShoot = true; // Variable para controlar si el enemigo puede disparar

    void Start()
    {

    }

    void Update()
    {
        tiempoUltimoDisparo += Time.deltaTime;
        if (canShoot && tiempoUltimoDisparo >= intervaloDisparo)
        {
            Shoot();
            tiempoUltimoDisparo = 0.0f;
        }
    }

    public void Shoot()
    {
        GameObject newBullet = Instantiate(bullet, controladorDisparo.position, controladorDisparo.rotation);
        Destroy(newBullet.gameObject, 1.0f); // Destruir la bala despu�s de 1 segundo
    }

    // M�todo para habilitar o deshabilitar el disparo
    public void EnableShooting(bool enable)
    {
        canShoot = enable;
    }
}