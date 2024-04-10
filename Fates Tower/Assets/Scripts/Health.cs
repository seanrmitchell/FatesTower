using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    public TextMeshProUGUI healthText;
    public GameOver gameOver;

    private float currentHealth;

    private void Awake()
    {
        currentHealth = health;
        healthText.text = health.ToString();
    }

    public float GetHealth()
    {
        return currentHealth;
    }

    public void DealDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            gameOver.OnDeath(gameObject.tag);
            Debug.Log(gameObject.name + " DIED!");
        }

        healthText.text = GetHealth().ToString();
    }
}
