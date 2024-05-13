using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combat : MonoBehaviour
{
    [Header("Animacion")]
    public Animator animator;
    public float vida;
    public float maximoVida;
    public HealthBar healthBar;
    public Slider slider;

    public void Start()
    {
        animator = GetComponent<Animator>();
        vida = maximoVida;
        healthBar.InicializeHealthBar(vida);
        slider = GetComponent<Slider>();
        animator.SetFloat("vida", vida);
    }

    public void TomarDaño(float daño)
    {
        vida -= daño;
        animator.SetFloat("vida", vida);
        healthBar.ChangeActualLife(vida);
        if(vida <= 0)
        {
            Destroy(gameObject);
        }
        

    }
    public void ChangeMaxLife(float maxLife)
    {
        slider.value = maxLife;
    }

    public void ChangeActualLife(float actualLife)
    {
        slider.value = actualLife;
        
    }

    public void InicializeHealthBar(float actualHealth)
    {
       
        ChangeMaxLife(actualHealth);
        ChangeActualLife(actualHealth);

    }
}
