using System.Collections;
using UnityEngine;

public class WeaponController2 : MonoBehaviour
{
    public GameObject bulletPrefab;
    public AudioClip clickSound; // Zvukový klip pro kliknutí
    public Transform bulletSpawn;
    private bool canAttack = true;
    private float lastAttackTime;
    public float shootCooldown = 1f;
    public AudioSource audioSource; // Přidáme AudioSource pro přehrávání zvuku

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canAttack)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (Time.time >= lastAttackTime + shootCooldown)
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            Vector3 shootDirection = transform.forward;
            bullet.GetComponent<Rigidbody>().velocity = shootDirection * 10f;
            StartCoroutine(ResetCooldown());
            lastAttackTime = Time.time;

            // Přehrání zvuku při střelbě
            audioSource.PlayOneShot(clickSound);
        }
    }

    IEnumerator ResetCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(shootCooldown);
        canAttack = true;
    }
}