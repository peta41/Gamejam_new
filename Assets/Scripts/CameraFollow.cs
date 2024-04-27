using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform; // Odkaz na transform hráče
    public Vector3 offset; // Posun kamery vzhledem k hráči

    void Update()
    {
        // Aktualizuje pozici kamery tak, aby byla nad hráčem
        transform.position = playerTransform.position + offset;
    }
}