using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combat : MonoBehaviour
{
    public float vida;
    public float maximoVida;
    public HealthBar healthBar;
    public Slider slider;

    public void Start()
    {
        vida = maximoVida;
        healthBar.InicializeHealthBar(vida);
        slider = GetComponent<Slider>();
    }

    public void TomarDaño(float daño)
    {
        vida -= daño;
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
