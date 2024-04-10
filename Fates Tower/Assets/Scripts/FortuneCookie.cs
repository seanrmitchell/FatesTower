using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FortuneCookie : MonoBehaviour
{
    public Health enemyHealth;
    public Health playerHealth;
    public AudioSource aud;

    private float genHealth;
    public float[] damage;
    public int[] probs;

    private void Start()
    {
        genHealth = (enemyHealth.GetHealth() + playerHealth.GetHealth())/2;
    }
    public void ProbChoice(string type)
    {
        // % chance for enemy to deal 10 dmg to player
        // % chance for player to deal 10 dmg to enemy
        int prob = 50;
        float dmg = 10;

        switch (type)
        {
            case "easy":
                dmg = Mathf.Round(damage[0] * genHealth);
                prob = probs[0];
                break;
            case "medium":
                dmg = Mathf.Round(damage[1] * genHealth);
                prob = probs[1];
                break;
            case "hard":
                dmg = Mathf.Round(damage[2] * genHealth);
                prob = probs[2];
                break;
        }

        var b = Rolling(prob);

        if (b)
        {
            enemyHealth.DealDamage(dmg);
            Debug.Log("Player Dealt " + dmg + " Damage!");
        }
        else
        {
            playerHealth.DealDamage(dmg);
            aud.Play();
            Debug.Log("Player Takes " + dmg + " Damage!");
        }
    }

    private bool Rolling(int prob)
    {
        int r = Random.Range(1, 101);
        Debug.Log(r);

        if (r > prob)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
