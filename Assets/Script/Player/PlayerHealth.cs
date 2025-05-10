using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    //public PlayerStats stats;
    public float Health = 100f;
    public float maxHealth;
    public float currentHealth;
    public UnityEngine.UI.Image HealthBar;
    public GameObject LoseCanvas;
    private float nextAttackTime = 0f;
    private bool isDead = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxHealth = Health;
        currentHealth = maxHealth;
        isDead = false;
        updateHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y) && currentHealth < maxHealth && !isDead)
        {
            gainHP(25);
            Debug.Log("Gained HP");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("BadGuy"))
        {
            nextAttackTime = Time.time + 1f;
            takeDamage(50);
            Debug.Log("Took Damage");
            Debug.Log("Health: " + currentHealth);
        }
    }

    public void takeDamage(float damage)
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
        isDead = true;
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
