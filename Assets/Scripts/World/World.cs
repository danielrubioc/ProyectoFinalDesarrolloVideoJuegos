using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    // Instantiate enemy
    public GameObject enemy;
    // Instantiate player
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    { 
        invokeEnemy(15); 
    }

    // Update is called once per frame
    void Update()
    { 
        //count enemies
        int enemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        //temporizador para invocar al jugador
        if (Time.time > 5 && enemies == 0)
        {
            invokeEnemy(15);
        }
    }

    // void invokeEnemy params int totalEnemies

    void invokeEnemy (float totalEnemies = 1)
    {
        // for loop to instantiate enemies
        for (int i = 0; i < totalEnemies; i++)
        {
            // random position
            Vector3 randomPosition = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
            // random rotation 
            Quaternion randomRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
            // Instantiate enemy
            Instantiate(enemy, randomPosition, randomRotation); 
        }
    }

    void invokePlayer ()
    {
        // random position
        Vector3 randomPosition = new Vector3(0, 0, 0);
        // random rotation 
        Quaternion randomRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
        // Instantiate player
        Instantiate(player, randomPosition, randomRotation);
    }
}
