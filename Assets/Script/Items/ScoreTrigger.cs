using TMPro;
using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    public int requiredScore = 2;
    public GameObject winCanvas;
    private ScoreManager scoreManager;
    private int currentScore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        winCanvas.SetActive(false);
    }

    // Update is called once per frame
    public void UpdateScore(int score)
    {
        currentScore = score;

        if (currentScore >= requiredScore)
        {
            ShowWinScreen();
        }
    }

    void ShowWinScreen()
    {
        winCanvas.SetActive(true);
        Debug.Log("Win Screen Displayed");
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
