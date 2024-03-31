using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boton : MonoBehaviour
{
    public bool botonIsActive;

    // Start is called before the first frame update
    void Start()
    {
        botonIsActive = false;
    }

    // Update is called once per frame

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            botonIsActive = true;
        }
        else if(other.gameObject.CompareTag("Box"))
        {
            botonIsActive = true;
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            botonIsActive = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            botonIsActive = false;
        }
        else if (other.gameObject.CompareTag("Box"))
        {
            botonIsActive = false;
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            botonIsActive = false;
        }
    }
}
