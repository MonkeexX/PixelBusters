using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door2 : MonoBehaviour
{
    public GameObject boss;
    // Start is called before the first frame update
    private void Update()
    {
        if (boss == null)
        {
            Destroy(gameObject);
        }
    }    
}