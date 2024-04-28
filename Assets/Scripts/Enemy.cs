using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
        void OnTriggerEnter(Collider other)
    {
        // Zkontrolujte, zda se kolidující objekt jmenuje "Enemy"
        if (other.gameObject.CompareTag("Player"))
        {
            // Získání skriptu Enemy z kolidujícího objektu
            Player player = other.gameObject.GetComponent<Player>();

            // Kontrola, zda má objekt skript Enemy
            if (player != null)
            {
                
                // Aplikace škody na objekt "Enemy"
                player.TakeDamage(10); // Předpokládáme, že metoda TakeDamage přijímá hodnotu škody jako argument
            }
        }
    }
}
