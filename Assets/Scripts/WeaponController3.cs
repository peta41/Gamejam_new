using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController3 : MonoBehaviour
{
    [SerializeField]
    public GameObject Axe;
    public GameObject AxeHitbox;
    public int damage = 10; // Poškození, které hráči způsobí

    void Start()
    {
        AxeHitbox.SetActive(false); // AxeHitbox je neaktivní na začátku
    }

    void Update()
    {
        // Logika pro aktivování AxeHitbox, například při stisknutí tlačítka
    }

    void OnTriggerEnter(Collider other)
    {
        // Kontrola, zda AxeHitBox narazil na hráče
        if (other.gameObject.CompareTag("Player"))
        {
            // Získání skriptu EnemyStats z hráče
            EnemyStats enemyScript = other.gameObject.GetComponent<EnemyStats>();

            // Kontrola, zda má hráč skript EnemyStats
            if (enemyScript != null)
            {
                // Aplikace škody na hráče
                enemyScript.TakeDamage(damage);
            }
        }
    }
}