using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager _instance = new UIManager();

    public TMP_Text healthText;
    public TMP_Text scoreText;
    public GameObject gameOverPanel;
    public GameObject youWinPanel;

    void Awake()
    {
        gameOverPanel.SetActive(false);
        youWinPanel.SetActive(false);
    }

    void Start()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    
    void Update()
    {
        
    }

    public void UpdateScoreText(float newScore)
    {
        scoreText.text = "Score: " + newScore.ToString("000");
    }

    public void UpdateLimoHealthText(int newHealth)
    {
        if (newHealth <= 0)
        {
            GameOverScreen();
            healthText.text = "Limo Health: 0";
        }
        healthText.text = "Limo Health: " + newHealth;
    }

    public void GameOverScreen()
    {
        gameOverPanel.SetActive(true);
    }

    public void YouWinScreen()
    {
        youWinPanel.SetActive(true);
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
