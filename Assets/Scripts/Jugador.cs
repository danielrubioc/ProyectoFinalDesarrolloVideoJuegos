using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public float velocidadMovimiento = 0.5f;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    { 
        rb = GetComponent<Rigidbody>();
    } 
   

    void FixedUpdate()
    {
        Mover();
    }

    void Mover()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Debug.Log("Horizontal: " + horizontal);

        Vector3 movimiento = new Vector3(horizontal, 0, vertical);
        rb.AddForce(movimiento * velocidadMovimiento);
    }
}
