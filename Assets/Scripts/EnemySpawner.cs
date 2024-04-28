using System.Collections;
using UnityEngine;
using UnityEngine.UI; // Přidáno pro práci s UI
using System.Collections.Generic; // Přidáno pro práci s kolekcemi
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab nepřátelské postavy
    public Transform[] spawnPoints; // Pole spawn pointů
    public float[] timeBetweenWaves; // Pole časů mezi vlnami
    public float timeBetweenSpawns = 0.5f; // Čas mezi generováním jednotlivých nepřátelských postav
    public  int[] numberOfEnemies; // Počet nepřátelských postav v každé vlně
    public Text enemyCountText; // UI komponenta pro zobrazení počtu nepřátel

    private bool GameCanEnd = false;
    private int waveIndex = 0;
    public static List<GameObject> currentEnemies = new List<GameObject>(); // Seznam aktuálně spawnovaných nepřátel

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

 IEnumerator SpawnWaves()
{
    while (true)
    {
        if (waveIndex < numberOfEnemies.Length)
        {
            // Resetování počtu nepřátel na začátku každé nové vlny
            int enemiesToSpawn = numberOfEnemies[waveIndex];
            currentEnemies.Clear(); // Odebrání všech aktuálně spawnovaných nepřátel

            for (int i = 0; i < enemiesToSpawn; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(timeBetweenSpawns);
            }

            // Pokud je další vlna, čekáme na určený čas
            if (waveIndex + 1 < timeBetweenWaves.Length)
            {
                yield return new WaitForSeconds(timeBetweenWaves[waveIndex]);
            }
            else
            {   
                GameCanEnd = true;
                Debug.Log("Všechny vlny byly generovány.");
                break;
            }

            waveIndex++;
        }
    }
}

    void SpawnEnemy()
    {
        // Výběr náhodného spawn pointu
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        currentEnemies.Add(enemy); // Přidání spawnovaného nepřátelce do seznamu
    }

 void Update()
{
    // Aktualizace UI s počtem nepřátel v aktuální vlně
    if (waveIndex < numberOfEnemies.Length)
    {
        enemyCountText.text = "Enemies to kill: " + numberOfEnemies[waveIndex].ToString();
    }
    else
    {
        enemyCountText.text = "All enemies have been spawned.";
    }

    if(currentEnemies.Count == 0 && GameCanEnd == true)
    {
        SceneManager.LoadScene(7);
    }
}


    public void EnemyDestroyed(GameObject enemy)
    {
        currentEnemies.Remove(enemy); // Odebrání zničeného nepřátelce ze seznamu
        numberOfEnemies[waveIndex]--;
    }


    private static bool isResetComplete = false;

    public static void ResetCurrentEnemies()
    {
        // Logika pro resetování nepřátel
        currentEnemies.Clear();
        // Po dokončení resetování nastavte isResetComplete na true
        isResetComplete = true;
    }

    public static bool IsResetComplete()
    {
        return isResetComplete;
    }


}