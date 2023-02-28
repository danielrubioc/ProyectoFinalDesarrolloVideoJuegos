using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float velocidadMovimiento = 100;
    public bool isWalking = false;
    private Rigidbody rb; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        move();
    }

    void move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movimiento = new Vector3(horizontal, 0, vertical);

        if(movimiento != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movimiento), 0.15f);
            isWalking = true;
        }
        else
        {
            isWalking = false;
        } 
        rb.AddForce(movimiento * velocidadMovimiento * Time.deltaTime);
    }

    void Respawn()
    {
        transform.position = new Vector3(0, 0, 0);
    }
}
