using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int damage = 10;

    void OnCollisionEnter(Collision collision)
    {
        // Kontrola, zda se nepřítel dotkl hráče
        if (collision.gameObject.CompareTag("Player"))
        {
            // Získání skriptu Player z hráče
            Player playerScript = collision.gameObject.GetComponent<Player>();

            // Kontrola, zda má hráč skript Player
            if (playerScript != null)
            {
                // Aplikace škody na hráče
                playerScript.TakeDamage(damage);
            }
        }
    }
}
