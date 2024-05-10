using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider slider;
    public int actualHealthPlayer = 100;
    public Material damage;

    

    public void Start()
    {
        slider = GetComponent<Slider>();

        damage.SetFloat("_to_see", 0.0f);

    }

    public void ChangeMaxLife(float maxLife)
    {
        slider.value = maxLife;
    }

    public void ChangeActualLife(float actualLife)
    {
        slider.value -= actualLife;

        if (slider.value <= 20)
        {
            damage.SetFloat("_to_see", 1.17f);
        }
        else
        {
            damage.SetFloat("_to_see", 0.0f);
        }
    }

    public void InicializeHealthBar(float actualHealth)
    {
        ChangeMaxLife(actualHealth);
        //ChangeActualLife(actualHealth);
    }
}
