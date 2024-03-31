using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [Header("Animacion")]
    public Animator animator;
    private bool disparo;
    public Transform controladorDisparo;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")) 
        {
            Shoot();
            disparo = true;
            animator.SetBool("disparo",disparo);
            


        }
        disparo = false;

    }

    private void Shoot()
    {
        GameObject NewBullet = Instantiate(bullet, controladorDisparo.position, controladorDisparo.rotation);
        Destroy(NewBullet.gameObject, 1.0f);
    }
}
