using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private float health = 100f;
    private float damage = 10f;
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
            /* other.gameObject.GetComponent<Jugador>().TakeDamage(damage); */
        }
    }
 
}
