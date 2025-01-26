using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Metoda do zmiany sceny
    public void PlayGame()
    {
        SceneManager.LoadScene("Scenes/MainScene"); // Zmieñ "GameScene" na nazwê swojej sceny z gr¹
    }

    // Metoda do wy³¹czenia aplikacji
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Gra zosta³a zamkniêta."); // Informacja w konsoli (dzia³a tylko w edytorze)
    }
}
