using UnityEngine;
using UnityEngine.UI;

public class Enemy1 : MonoBehaviour
{
    public int maxHealth = 3;      // Maximum health of the enemy
    private int currentHealth;    // Current health of the enemy

    public Image[] hearts;        // Array of full-heart images (UI)

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }

        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        // Disable hearts one by one based on current health
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].enabled = true;  // Show the heart if it's within the current health
            }
            else
            {
                hearts[i].enabled = false; // Hide the heart if health is lost
            }
        }
    }

    private void Die()
    {
        Debug.Log("Enemy1 has died!");
        Destroy(gameObject); // Destroy the enemy object when health reaches 0
    }
}
