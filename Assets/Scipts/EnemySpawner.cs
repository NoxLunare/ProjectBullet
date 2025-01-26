using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // Prefab przeciwnika
    public Transform[] spawnPoints; // Tablica punkt�w spawnu
    public int maxEnemies = 10;     // Maksymalna liczba przeciwnik�w na mapie
    public float spawnInterval = 5f; // Czas mi�dzy spawnami

    private int currentEnemyCount = 0; // Liczba przeciwnik�w obecnie na mapie

    void Start()
    {
        // Rozpocznij cykliczne tworzenie przeciwnik�w
        InvokeRepeating(nameof(SpawnEnemy), 0f, spawnInterval);
    }

    private void SpawnEnemy()
    {
        // Sprawd�, czy mo�na jeszcze stworzy� przeciwnik�w
        if (currentEnemyCount < maxEnemies)
        {
            // Wybierz losowy punkt spawnu
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            // Stw�rz przeciwnika w wybranym punkcie
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

            // Zwi�ksz licznik przeciwnik�w
            currentEnemyCount++;
        }
    }

    public void EnemyDied()
    {
        // Zmniejsz licznik przeciwnik�w, gdy przeciwnik zostanie zniszczony
        currentEnemyCount = Mathf.Max(0, currentEnemyCount - 1);
    }
}
