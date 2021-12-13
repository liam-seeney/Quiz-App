using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private int score;
    private int scoreIncrement = 5;

    public static ScoreController Instance;

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
        score += scoreIncrement;
    }

    public void DisplayScore()
    {
        scoreText.text = score.ToString();
    }
}
