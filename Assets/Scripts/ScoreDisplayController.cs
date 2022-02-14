using TMPro;
using UnityEngine;

public class ScoreDisplayController : MonoBehaviour
{
    private int currentScore;
    private int bestScore;

    private ScoreController scoreController;
    [SerializeField] private TextMeshProUGUI gameOverTextField;
    [SerializeField] private TextMeshProUGUI bestScoreTextField;

    private void Start()
    {
        scoreController = FindObjectOfType<ScoreController>();
        currentScore = scoreController.GetScore();
        LoadGameData();
        DisplayScore();
        SaveGame(scoreController);
    }

    private void LoadGameData()
    {
        GameSessionStats currentGame = SaveController.LoadGameData();
        bestScore = currentGame.bestScore;
    }

    private void SaveGame(ScoreController scoreController)
    {
        if (currentScore > bestScore)
        {
            SaveController.SaveGameData(scoreController);
        }
    }

    private void DisplayScore()
    {
        gameOverTextField.text = $"Your score for this round was: {currentScore}";
        bestScoreTextField.text = $"Best Score: {bestScore}";
    }
}
