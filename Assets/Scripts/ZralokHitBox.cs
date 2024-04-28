using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZralokHitbox : MonoBehaviour
{
    public int damageAmount = 50; // Množství škody, které se aplikuje
    public AudioClip hitSound; // Zvukový klip, který se spustí při kolizi
    public AudioSource audioSource; // Komponenta AudioSource pro spuštění zvuku

    void Start()
    {
        // Získání komponenty AudioSource
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        // Zkontrolujte, zda se kolidující objekt jmenuje "Enemy"
        if (other.gameObject.CompareTag("Enemy"))
        {
            // Získání skriptu EnemyStats z kolidujícího objektu
            EnemyStats enemyScript = other.gameObject.GetComponent<EnemyStats>();

            // Kontrola, zda má objekt skript EnemyStats
            if (enemyScript != null)
            {
                Debug.Log("Zralok hit");
                // Aplikace škody na objekt "Enemy"
                enemyScript.TakeDamage(damageAmount); // Aplikace škody

                // Spuštění zvuku
                if (audioSource != null && hitSound != null)
                {
                    audioSource.PlayOneShot(hitSound);
                }
            }
        }
    }
}