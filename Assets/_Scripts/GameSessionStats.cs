using UnityEngine;

[System.Serializable]
public class GameSessionStats
{
    public int bestScore;

    public GameSessionStats(ScoreController currentGameScores)
    {
        bestScore = currentGameScores.GetScore();
    }
}
