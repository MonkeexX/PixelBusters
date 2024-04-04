using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
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
