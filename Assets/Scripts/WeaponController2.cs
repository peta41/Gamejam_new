using System.Collections;
using UnityEngine;

public class WeaponController2 : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    private float lastAttackTime;
    public bool CanAttack = true;
    [SerializeField] public float firerate = 0.5f;
    public float bulletLife = 3f;
    public float shootDelay = 1f; // Delay před střílením

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && CanAttack)
        {
            StartCoroutine(ShootWithDelay(shootDelay));
        }
    }

    IEnumerator ShootWithDelay(float delay)
    {
        CanAttack = false; // Zakáže další střílení během delayu
        yield return new WaitForSeconds(delay); // Čeká zadaný delay
        Shoot(); // Volá metodu Shoot po uplynutí delayu
        CanAttack = true; // Umožní další střílení po skončení delayu
    }

    void Shoot()
    {
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