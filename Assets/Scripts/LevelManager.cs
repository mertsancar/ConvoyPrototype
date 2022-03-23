using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject player;
    private float score;
    private float difficulty_level = 1;
    private float max_difficulty_level = 100;
    private float finalLevel = 100;
    private int score_to_next_level = 3;

    void Start()
    {

    }

    void Update()
    {
        if (score >= finalLevel)
        {
            UIManager._instance.YouWinScreen();
            return;
        }
        if (UIManager._instance.gameOverPanel.activeSelf)
        {
            return;
        }

        if (score >= score_to_next_level)
        {
            LevelUp();
        }
        score += Time.deltaTime * difficulty_level;
        UIManager._instance.UpdateScoreText(score);
    }

    void LevelUp()
    {
        if (difficulty_level == max_difficulty_level)
        {
            return;
        }

        score_to_next_level *= 2;
        difficulty_level++;

        player.GetComponent<PlayerMovement>().SetSpeed(difficulty_level);
    }
}
