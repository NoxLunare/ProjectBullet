using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton, aby �atwo odwo�ywa� si� do mened�era punkt�w

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreText2;// Tekst w UI do wy�wietlania punkt�w
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
        UpdateScoreText(); // Zaktualizuj tekst na pocz�tku gry
    }

    public void AddPoint()
    {
        score++; // Dodaj punkt
        UpdateScoreText(); // Zaktualizuj tekst w UI
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Number of kills: " + score; // Wy�wietl wynik w formacie "Score: X"
        scoreText2.text = "Your Score: " + score;
    }
}
