using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score = 0;
    public int minScore;
    public int currentScore;
    public int requiredScore = 2;
    public GameObject scoreItem;
    public Text scoreText;
    public GameObject winCanvas;
    public GameObject scoreTextRoot;
    public GameObject winCanvasRoot;
     

    void Start()
    {
        ResetWinScreen();
        //winCanvas.SetActive(false);
        ResetScore();
        Debug.Log("Score: " + score);
        if (instance == null)
        {
            instance = this;
            if (scoreItem == null)
            {
                scoreItem = GameObject.FindGameObjectWithTag("ScoreItem");
            }
        }
        else
        {
            Debug.Log("ScoreManager.Start() else");
            score = 0;
        }

        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(scoreTextRoot);
        DontDestroyOnLoad(winCanvasRoot);
    }

    public void UpdateScore(int score)
    {
        currentScore = score;
        Debug.Log("Current score: " + score);

        if (currentScore >= requiredScore)
        {
            Debug.Log("Score is sufficient");
            ShowWinScreen();
        }
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScoreText();
    }
    
    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }

    public void ResetScore()
    {
        Debug.Log("ResetScore() called");
        score = 0;
        UpdateScoreText();
    }

    void ShowWinScreen()
    {
        winCanvas.SetActive(true);
        Debug.Log("Win Screen Displayed");
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        ResetScore();
    }

    void ResetWinScreen()
    {
        Debug.Log("ResetWinScreen() called");
        winCanvas.SetActive(false);
    }
}
