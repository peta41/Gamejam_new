using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Add TextMeshPro namespace

public class Player : MonoBehaviour
{
    public int hp;
    public int maxHP = 100;
    public TextMeshProUGUI healthText; // Reference to TextMeshPro object for health display


    void Start()
    {
        hp = maxHP;
        UpdateHealthUI(); // Update health UI on start
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Die();
        }
        UpdateHealthUI(); // Update health UI whenever health changes
    }

    void Update()
    {
        // You can add any additional logic here if needed
    }

    private void Die()
    {
        // Death logic

        EnemySpawner.ResetCurrentEnemies();
        StartCoroutine(LoadNextScene());

    }

  IEnumerator LoadNextScene()
    {
    // Předpokládáme, že EnemySpawner má metodu IsResetComplete, která vrací true, když je resetování dokončeno
        yield return new WaitUntil(() => EnemySpawner.IsResetComplete());

    // Načtení scény s indexem 2
        SceneManager.LoadScene(2);
    }

    // Function to update the health UI
    private void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + hp.ToString(); // Update health text
        }
    }
}
