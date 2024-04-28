using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; // Přidáme pro práci s scénami
public class Player : MonoBehaviour
{
    public int hp;
    public int maxHP = 100;
    
    public string nextSceneName = "DeathScene"; // Název scény, na kterou se přejde po smrti

    void Start()
    {
        hp = maxHP;

    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Die();
        }
    }

    void Update()
    {

    }
       private void Die()
    {
        // Spuštění animace smrti


        // Po 3 sekundách se spustí jiná scéna
        StartCoroutine(LoadNextSceneAfterDelay(3f));
    }

    IEnumerator LoadNextSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("DeathScene"); // Načtení další scény
    }
}