using TMPro;
using UnityEngine;

public class ScoreDisplayController : MonoBehaviour
{
    private int _currentScore;
    private int _bestScore;

    private ScoreController _scoreController;
    [SerializeField] private TextMeshProUGUI gameOverTextField;
    [SerializeField] private TextMeshProUGUI bestScoreTextField;

    private void Start()
    {
        _scoreController = FindObjectOfType<ScoreController>();
        _currentScore = _scoreController.GetScore();
        LoadGameData();
        DisplayScore();
        SaveGame(_scoreController);
    }

    private void LoadGameData()
    {
        GameSessionStats currentGame = SaveController.LoadGameData();
        if (currentGame == null) return;
        _bestScore = currentGame.bestScore;
    }

    private void SaveGame(ScoreController scoreController)
    {
        if (_currentScore > _bestScore)
        {
            SaveController.SaveGameData(scoreController);
        }
    }

    private void DisplayScore()
    {
        gameOverTextField.text = $"Your score for this round was: {_currentScore}";
        bestScoreTextField.text = $"Best Score: {_bestScore}";
    }
}
