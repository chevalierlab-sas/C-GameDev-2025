using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    ScoreManager scoreManager;

    public void Restart()
    {
        Debug.Log("Game restarted from win screen");
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("0MainMenu");
        Debug.Log("Quitted from Endgame");
    }
}
