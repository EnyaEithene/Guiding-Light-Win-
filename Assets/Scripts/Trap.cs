using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public float bounceForce = 10f;
    public int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HandlePlayerBounce(collision.gameObject);
        }
    }

    private void HandlePlayerBounce(GameObject player)
    {
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();

        if (rb)
        {
            // Resetare velocitate jucator
            rb.velocity = new Vector2(rb.velocity.x, 0f);

            // Aplica forta de salt
            rb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
        }
    }
}
