using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public PlayerStats stats;
    public float maxHealth;
    public float currentHealth;
    public UnityEngine.UI.Image HealthBar;
    public GameObject LoseCanvas;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxHealth = stats.Health;
        currentHealth = maxHealth;
        updateHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y) && currentHealth < maxHealth)
        {
            gainHP(10);
            Debug.Log("Gained HP");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("BadGuy"))
        {
            takeDamage(15);
            Debug.Log("Took Damage");
            Debug.Log("Health: " + currentHealth);
        }
    }

    void takeDamage(float damage)
    {
        currentHealth = currentHealth - damage;
        if (currentHealth <= 0)
        {
            Die();
            Debug.Log("Dead");
        }
        updateHealthBar();
    }

    void gainHP(float amount)
    {
        if (currentHealth < maxHealth)
        {
            currentHealth = currentHealth + amount;
            updateHealthBar();
        }
        else
        {
            Debug.Log("Max Health");
        }
    }

    void updateHealthBar()
    {
        HealthBar.fillAmount = currentHealth/maxHealth;
    }

    void Die()
    {
        ShowLoseScreen();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void ShowLoseScreen()
    {
        LoseCanvas.SetActive(true);
        Debug.Log("Lose Screen Displayed");
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
