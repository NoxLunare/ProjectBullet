using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton, aby ³atwo odwo³ywaæ siê do mened¿era punktów

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreText2;// Tekst w UI do wyœwietlania punktów
    private int score = 0;
    public EnemySpawner maxEnemies;
    public GameObject panelFinalny;
    public GameObject sliderHealth;
    public GameObject panelScore;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        maxEnemies.maxEnemies = 100;
        panelFinalny.SetActive(false);
        panelScore.SetActive(true);
        sliderHealth.SetActive(true);
        score = 0;
        // Ustawienie singletona
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateScoreText(); // Zaktualizuj tekst na pocz¹tku gry
    }

    public void AddPoint()
    {
        score++; // Dodaj punkt
        UpdateScoreText(); // Zaktualizuj tekst w UI
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Number of kills: " + score; // Wyœwietl wynik w formacie "Score: X"
        scoreText2.text = "Your Score: " + score;
    }
}
