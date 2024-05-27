using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Transform controladorDisparo;
    public Transform controladorDisparoHaciAbajo;
    public GameObject bullet;
    public GameObject ball;
    public float intervaloDisparo = 3.0f; // Intervalo entre disparos en segundos
    private float tiempoUltimoDisparo = 0.0f; // Tiempo del último disparo
    private bool canShoot = true; // Variable para controlar si el enemigo puede disparar

    public bool elevado = false;

    void Start()
    {

    }

    void Update()
    {
        tiempoUltimoDisparo += Time.deltaTime;
        if (canShoot && tiempoUltimoDisparo >= intervaloDisparo)
        {
            if (!elevado)
            {
                Shoot();
            }
            else
            {
                SpecialShoot();
            }
            tiempoUltimoDisparo = 0.0f;
        }
    }

    public void Shoot()
    {
        GameObject newBullet = Instantiate(bullet, controladorDisparo.position, controladorDisparo.rotation);
        Destroy(newBullet.gameObject, 1.0f); // Destruir la bala después de 1 segundo
    }

    public void SpecialShoot()
    {
        GameObject specialBullet = Instantiate(ball, controladorDisparo.position, controladorDisparoHaciAbajo.rotation);
        Destroy(specialBullet.gameObject, 10.0f);
    }

    // Método para habilitar o deshabilitar el disparo
    public void EnableShooting(bool enable)
    {
        canShoot = enable;
    }
}