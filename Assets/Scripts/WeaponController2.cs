using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController2 : MonoBehaviour
{
    public GameObject bulletPrefab;  // Reference to the bullet prefab
    public Transform bulletSpawn;    // Transform of the bullet spawn point
    private float lastAttackTime;
    public bool CanAttack = true;
    [SerializeField]
    public float firerate = 0.5f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && CanAttack)
        {
            CanAttack = false;
            lastAttackTime = Time.time;

            // Shoot towards cursor
            ShootTowardsCursor();
        }
    }

    void FixedUpdate()
    {
        if (!CanAttack && Time.time >= lastAttackTime + firerate)
        {
            CanAttack = true;
        }
    }

    private void ShootTowardsCursor()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.transform.position.y - bulletSpawn.position.y));
        Vector3 shootingDirection = (mousePosition - bulletSpawn.position).normalized;
        Quaternion bulletRotation = Quaternion.LookRotation(shootingDirection);
        Instantiate(bulletPrefab, bulletSpawn.position, bulletRotation);
    }
}