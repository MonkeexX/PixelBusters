using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    float xInicial;
    float yInicial;
    // Start is called before the first frame update
    void Start()
    {
        xInicial = transform.position.x;
        yInicial = transform.position.y;
    }

    // Update is called once per frame
    public void Recolocar()
    {
        transform.position = new Vector3(xInicial, yInicial, 0);

    }

}
