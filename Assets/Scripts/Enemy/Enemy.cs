using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject explosionEffect;
    public GameObject enemy;
    public float explosionRadius = 5f;
    public float explosionForce = 30f;
    public float damage = 100f;
    public int selfDestructTime = 4;
    private float health = 100f;
    private float counter = 0f;

    private int randomDificulty;

    //start
    void Start()
    {
        enemyDificulty();
    }

    // Update is called once per frame
    void Update()
    {
       EnemyNavMeshAgent();
    }

    private void EnemyNavMeshAgent()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        //get the player position
        GameObject player = GameObject.Find("Player");
        agent.SetDestination(player.transform.position);
        //set random value between 1 and 3
    }

    void enemyDificulty()
    {
        switch (Random.Range(1, 3))
        {
            case 1:
                selfDestructTime = 1;
                break;
            case 2:
                selfDestructTime = 2;
                break;
            case 3:
                selfDestructTime = 3;
                break;
        }

    }

    private void ExplosionEffect()
    {
        /* Instantiate(explosion, transform.position, transform.rotation); */
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius); 
            }
        }

        Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(enemy, 0.2f); 

    }

    private void OnCollisionEnter(Collision collision)
    {
         Debug.Log("OnCollisionEnter");
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Player has been hit");
            /* collision.gameObject.GetComponent<Jugador>().TakeDamage(damage); */
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        if (other.gameObject.name == "Player")
        {
            Debug.Log("Player has been hit"); 
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player")
        { 
            counter += Time.deltaTime;
            if (counter >= selfDestructTime)
            {
                Debug.Log("Explota"); 
                ExplosionEffect();
                /* other.gameObject.GetComponent<Jugador>().TakeDamage(damage); */
            } 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            counter = 0;
        }
    }
}
