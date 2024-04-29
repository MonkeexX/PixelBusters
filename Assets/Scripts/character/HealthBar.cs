using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider slider;
    public int actualHealthPlayer = 100;
    [Header("Animacion")]
    public Animator animator;

    
    public void Start()
    {
        slider = GetComponent<Slider>();


    }
    public void Update()
    {
        animator.SetInteger("Vida", actualHealthPlayer);
    }
    public void ChangeMaxLife(float maxLife)
    {
        slider.value = maxLife;
        
    }

    public void ChangeActualLife(float actualLife)
    {
        slider.value -= actualLife;
        actualHealthPlayer =(int)slider.value;
    }

    public void InicializeHealthBar(float actualHealth)
    {
        
        ChangeMaxLife(actualHealth);
        //ChangeActualLife(actualHealth);
    }
}
