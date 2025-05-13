using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int bulletDamage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy)
        {
            enemy.TakeDamage(bulletDamage);

            Destroy(gameObject);
        }
    }
}
