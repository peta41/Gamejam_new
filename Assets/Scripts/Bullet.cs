using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 35;

    public float speed = 20f;
    public Rigidbody rb;

    void Start()
    {
        rb.velocity = transform.forward * speed;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Add what happens when bullet collides with another object
        Destroy(gameObject); // Destroy bullet on collision
    }
}