using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    public Health enemyHealth;
    public GameObject enemyPrefab;
    public AudioSource aud;

    private float currentEnemyNumbers;
    private List<GameObject> enemies;

    private void Start()
    {
        currentEnemyNumbers = enemyHealth.GetHealth();
        enemies = new List<GameObject>();

        for (int i = 0; i < enemyHealth.GetHealth(); i++)
        {
            Vector3 pos = new Vector3(Random.Range(-300f, 300f), 3.9f, Random.Range(0f, 200f));
            GameObject enemy = Instantiate(enemyPrefab, pos, enemyPrefab.transform.rotation);
            enemies.Add(enemy);
            Debug.Log(enemies[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth.GetHealth() < currentEnemyNumbers)
        {
            for (float i = enemyHealth.GetHealth(); i < currentEnemyNumbers; i++)
            {
                int r = Random.Range(0, enemies.Count);
                Destroy(enemies[r].gameObject);
                enemies.RemoveAt(r);
            }

            aud.Play();

            currentEnemyNumbers = enemyHealth.GetHealth();
        }
    }
}
