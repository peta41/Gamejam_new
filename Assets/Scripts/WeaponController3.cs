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

       if (other.gameObject.CompareTag("Player"))
        {
            // Vypíše zprávu do konzole Unity
            Debug.Log("Hit");

            // Získání skriptu Player z hráče
            Player playerScript = other.gameObject.GetComponent<Player>();

            // Kontrola, zda má hráč skript Player
            if (playerScript != null)
            {
                // Aplikace škody na hráče
                playerScript.TakeDamage(damage);
            }
        }
    }
}