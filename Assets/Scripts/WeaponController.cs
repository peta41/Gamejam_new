using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class WeaponController : MonoBehaviour
    {
    

    public GameObject zralok;
    public GameObject zralokHlavaHitbox;
    private float lastAttackTime;

    public bool CanAttack = true;

    [SerializeField]
    public float cooldown = 2f;

    private void Start()
    {
        zralokHlavaHitbox.SetActive(false);

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { 
            if (CanAttack) // hit enemy
            {
                Stab();
            }
        }
    }

    public void Stab()
    {
        CanAttack = false;
        lastAttackTime = Time.time;
        zralokHlavaHitbox.SetActive(true);
    }

    void FixedUpdate()
    {
        if (!CanAttack && Time.time >= lastAttackTime + cooldown)
        {
            zralokHlavaHitbox.SetActive(false);
            CanAttack = true;
        }
    }
}
