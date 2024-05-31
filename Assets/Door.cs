using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float reconstructionTime = 2.0f;
    private Collider2D door2Collider;
    private SpriteRenderer door2Renderer;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        door2Collider = GetComponent<Collider2D>();
        door2Renderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            door2Collider.enabled = false;
            door2Renderer.enabled = false;

            gameObject.SetActive(false);

            StartCoroutine(ReconstructionAfterTime());
        }
    }

    private IEnumerator ReconstructionAfterTime()
    {
        yield return new WaitForSeconds(reconstructionTime);

        gameObject.SetActive(true);

        door2Collider.enabled = true;
        door2Renderer.enabled = true;
    }
}
