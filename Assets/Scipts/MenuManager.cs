using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject panelMovement;

    private void Awake()
    {
        panelMovement.SetActive(false);
    }
    // Metoda do zmiany sceny
    public void PlayGame()
    {
        SceneManager.LoadScene("Scenes/MainScene");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Gra zosta³a zamkniêta."); 
    }

    public void OpenMovement()
    {
        panelMovement.SetActive(true);
    }
    public void CloseMovement()
    {
        panelMovement.SetActive(false);
    }
}
