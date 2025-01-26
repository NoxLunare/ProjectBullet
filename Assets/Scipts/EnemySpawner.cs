using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // Prefab przeciwnika
    public Transform[] spawnPoints; // Tablica punktów spawnu
    public int maxEnemies = 10;     // Maksymalna liczba przeciwników na mapie
    public float spawnInterval = 5f; // Czas miêdzy spawnami

    private int currentEnemyCount = 0; // Liczba przeciwników obecnie na mapie

    void Start()
    {
        // Rozpocznij cykliczne tworzenie przeciwników
        InvokeRepeating(nameof(SpawnEnemy), 0f, spawnInterval);
    }

    private void SpawnEnemy()
    {
        // SprawdŸ, czy mo¿na jeszcze stworzyæ przeciwników
        if (currentEnemyCount < maxEnemies)
        {
            // Wybierz losowy punkt spawnu
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            // Stwórz przeciwnika w wybranym punkcie
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

            // Zwiêksz licznik przeciwników
            currentEnemyCount++;
        }
    }

    public void EnemyDied()
    {
        // Zmniejsz licznik przeciwników, gdy przeciwnik zostanie zniszczony
        currentEnemyCount = Mathf.Max(0, currentEnemyCount - 1);
    }
}
