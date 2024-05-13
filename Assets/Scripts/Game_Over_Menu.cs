using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Over_Menu : MonoBehaviour
{
    // Start is called before the first frame update
   public void Retry()
    {
        SceneManager.LoadScene("Neon_Bullet");
    }

    public void Levels()
    {

    }

    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
