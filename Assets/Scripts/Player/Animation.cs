using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    public Animator anim;
    
    void Update()
    {
        // get player component
        GameObject player = GameObject.Find("Player"); 
        // player is walking
        if(player.GetComponent<Movement>().isWalking)
        {
            // play walking animation
            GetComponent<Animator>().SetBool("isWalking", true);
        }
        else
        {
            // stop walking animation
            GetComponent<Animator>().SetBool("isWalking", false);
        }
    }
}
