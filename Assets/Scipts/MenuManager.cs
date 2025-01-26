using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Metoda do zmiany sceny
    public void PlayGame()
    {
        SceneManager.LoadScene("Scenes/MainScene"); // Zmie� "GameScene" na nazw� swojej sceny z gr�
    }

    // Metoda do wy��czenia aplikacji
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Gra zosta�a zamkni�ta."); // Informacja w konsoli (dzia�a tylko w edytorze)
    }
}
