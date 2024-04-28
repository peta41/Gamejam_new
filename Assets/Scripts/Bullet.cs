using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 35;
    public float speed = 20f;
    public Rigidbody rb;
    public GameObject impactEffect; // Prefab pro efekt dopadu
    public AudioClip impactSound; // Audio klip pro zvuk dopadu

    void Start()
    {
        // Nastavení rychlosti střely bez delay
        rb.velocity = transform.forward * speed;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Kontrola, zda střela narazila na nepřítele
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Získání skriptu EnemyStats z kolidujícího objektu
            EnemyStats enemyScript = collision.gameObject.GetComponent<EnemyStats>();

            // Kontrola, zda má kolidující objekt skript EnemyStats
            if (enemyScript != null)
            {
                // Aplikace škody na nepřítele
                enemyScript.TakeDamage(damage); 

                


                // Vytvoření efektu dopadu na místě dopadu
                if (impactEffect != null)
                {
                    GameObject effectInstance = Instantiate(impactEffect, collision.contacts[0].point, Quaternion.LookRotation(collision.contacts[0].normal));
                    // Zničení efektu dopadu po 0.5 sekundách
                    Destroy(effectInstance, 0.5f);
                }

                // Přehrání zvuku dopadu
                if (impactSound != null)
                {
                    AudioSource.PlayClipAtPoint(impactSound, collision.contacts[0].point);
                }
            }
        }

        // Zničení střely po dopadu
        Destroy(gameObject);
    }
}