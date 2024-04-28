using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{

    private EnemySpawner enemySpawner;

    [SerializeField]
    public int maxHp = 100;
    private int hp;

   void Start()
{
    enemySpawner = FindObjectOfType<EnemySpawner>();
    hp = maxHp;
    Debug.Log("HP after initialization: " + hp);
}
    public int Hp
    {
        get { return hp; }
        set { hp = value; }
    }

    private void Die()
    {
        // Volání metody EnemyDestroyed z EnemySpawner
        enemySpawner.EnemyDestroyed(gameObject);
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        Debug.Log("HP after taking damage: " + hp);
        if (hp <= 0)
        {
            Die();
         }
    }
    
}