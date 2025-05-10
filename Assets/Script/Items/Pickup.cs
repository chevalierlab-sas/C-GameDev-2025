using UnityEngine;

public class Pickup : MonoBehaviour
{
    public int scoreValue = 1;

    private ScoreManager scoreManager;
    //private ScoreTrigger scoreTrigger;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        //scoreTrigger = FindObjectOfType<ScoreTrigger>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            ScoreManager.instance.AddScore(scoreValue);
            scoreManager.UpdateScore(scoreManager.score);
        }
        Destroy(gameObject);
    }
}
