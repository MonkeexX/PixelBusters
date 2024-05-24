using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb2D;
    public Transform player;

    public float timeMove;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        timeMove = 0;
    }

    // Update is called once per frame
    void Update()
    {
       timeMove += Time.deltaTime;

        if (timeMove >= 5.0f)
        {
            timeMove = 0;
        }
    }
}
