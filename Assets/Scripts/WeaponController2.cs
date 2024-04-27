using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController2 : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    private float lastAttackTime;
    public bool CanAttack = true;
    [SerializeField] public float firerate = 0.5f;
    public float bulletLife = 3f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (CanAttack)
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        CanAttack = false;
        lastAttackTime = Time.time;

        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        Vector3 shootDirection = transform.forward;

        bullet.GetComponent<Rigidbody>().velocity = shootDirection * 10f;

        StartCoroutine(DestroyBulletAfterDelay(bullet));
    }

    IEnumerator DestroyBulletAfterDelay(GameObject bullet)
    {
        yield return new WaitForSeconds(bulletLife);
        Destroy(bullet);
    }

    void FixedUpdate()
    {
        if (!CanAttack && Time.time >= lastAttackTime + firerate)
        {
            CanAttack = true;
        }
    }
}