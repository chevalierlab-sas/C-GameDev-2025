using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("1GameScene");
        Debug.Log("Game started from Main Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitted Game");
        Application.Quit();
    }
}
