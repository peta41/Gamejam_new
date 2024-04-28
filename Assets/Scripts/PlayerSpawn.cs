using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public float startYPosition = 0f; // Počáteční vertikální pozice

    void Start()
    {
        // Získání aktuální pozice hráče
        Vector3 currentPosition = transform.position;

        // Nastavení vertikální pozice na startYPosition
        currentPosition.y = startYPosition;

        // Přiřazení nové pozice hráči
        transform.position = currentPosition;
    }
}