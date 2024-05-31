using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float reconstructionTime = 1.0f;
    public Collider2D door2Collider;
    public SpriteRenderer door2Renderer;
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        door2Collider = GetComponent<Collider2D>();
        door2Renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            if(gameObject == null)
            {

                StartCoroutine(ReconstructionAfterTime());
            }
        }
    }
    private IEnumerator ReconstructionAfterTime()
    {
        door2Collider.enabled = false;
        door2Renderer.enabled = false;
        
        yield return new WaitForSeconds(reconstructionTime);
   
        door2Collider.enabled = true;
        door2Renderer.enabled = true;
    }
}
