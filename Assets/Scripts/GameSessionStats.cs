using UnityEngine;

[System.Serializable]
public class GameSessionStats
{
    public int bestScore;
    //private int bestScore;

    public GameSessionStats(ScoreController currentGameScores)
    {
        bestScore = currentGameScores.GetScore();
    }
}
