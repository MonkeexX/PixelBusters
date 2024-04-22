using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bandera : MonoBehaviour
{

    public int sceneBuildIndex;
    // Start is called before the first frame update
    public void CambiarNivel()
    {
        int nivelActual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(nivelActual + 1);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
       

            if (collision.gameObject.CompareTag("Player"))
            {
                CambiarNivel();
            }
      
    }

}
