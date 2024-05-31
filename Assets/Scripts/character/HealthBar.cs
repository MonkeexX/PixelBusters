using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider slider;
    public int actualHealthPlayer = 100;
    public GameObject life1;
    public GameObject life2;
    public GameObject life3;

    

    public void Start()
    {
        slider = GetComponent<Slider>();

    }

    public void ChangeMaxLife(float maxLife)
    {
        slider.value = maxLife;
    }

    public void ChangeActualLife(float actualLife)
    {
        slider.value -= actualLife;

        if (slider.value <= 0)
        {
            Destroy(life1);
            slider.value = 100;
            

            if (life1 == false)
            {
                Destroy(life2);

                if (life2 == false)
                {
                    Destroy(life3);
                    SceneManager.LoadScene("Game_Over");
                }
            }
        }
    }

    public void InicializeHealthBar(float actualHealth)
    {
        ChangeMaxLife(actualHealth);
        //ChangeActualLife(actualHealth);
    }
}
