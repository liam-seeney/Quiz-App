using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private int score;
    private int scoreMultiplier;
    private int scoreIncrement = 5;

    public static ScoreController Instance;

    private void OnEnable()
    {
        TimerController.TimeRemaining += ScoreMultiplier;
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public int GetScore()
    {
        return score;
    }

    public void IncrementScore()
    {
        score += scoreIncrement * scoreMultiplier;
    }

    private void ScoreMultiplier(float timeRemaining)
    {
        int multiplier = (int)Mathf.Round(timeRemaining);
        scoreMultiplier = multiplier;
    }
    public void DisplayScore()
    {
        scoreText.text = $"Score: {score}";
    }
}
