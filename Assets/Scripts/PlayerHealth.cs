using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    public HealthUI healthUI;

    private SpriteRenderer spriterenderer;

    public static event Action OnPlayedDied;
    // Start is called before the first frame update
    void Start()
    {
        ResetHealth();

        spriterenderer = GetComponent<SpriteRenderer>();
        GameController.OnReset += ResetHealth;
        healthItem.OnHealthCollect += Heal;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy)
        {
            TakeDamage(enemy.damage);
        }
        Trap trap = collision.GetComponent<Trap>();
        if (trap && trap.damage > 0)
        {
            TakeDamage(trap.damage);
        }
    }

    void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        healthUI.UpdateHearts(currentHealth);
    }

    void ResetHealth()
    {
        currentHealth = maxHealth;
        healthUI.SetMaxHearts(maxHealth);
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthUI.UpdateHearts(currentHealth);

        // Luminare a jucatorului cu rosu
        StartCoroutine(FlashRed());

        if (currentHealth <= 0)
        {
            // Jucatorul a pierdut -- apelare Game Over, animatii, etc.
            OnPlayedDied.Invoke();
        }
    }

    private IEnumerator FlashRed()
    {
        spriterenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        spriterenderer.color = Color.white;
    }
}
