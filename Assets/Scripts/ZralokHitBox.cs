using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZralokHitbox : MonoBehaviour
{

    // a jak na ně aplikovat škodu. Tento příklad předpokládá, že máte metodu TakeDamage v skriptu Enemy.

    void OnTriggerEnter(Collider other)
    {
        // Zkontrolujte, zda se kolidující objekt jmenuje "Enemy"
        if (other.gameObject.CompareTag("Enemy"))
        {
            // Získání skriptu Enemy z kolidujícího objektu
            EnemyStats enemyScript = other.gameObject.GetComponent<EnemyStats>();

            // Kontrola, zda má objekt skript Enemy
            if (enemyScript != null)
            {
                
                // Aplikace škody na objekt "Enemy"
                enemyScript.TakeDamage(100); // Předpokládáme, že metoda TakeDamage přijímá hodnotu škody jako argument
            }
        }
    }
}