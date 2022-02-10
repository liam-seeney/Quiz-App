using UnityEngine;
using System;
using System.Collections.Generic;

public class QuestionHandler : MonoBehaviour
{
    [SerializeField] private List<Question> availableQuestions;
    [SerializeField] private List<Question> gameQuestions = new List<Question>();

    private int gameLength = 5;
    private System.Random rand = new System.Random();

    public static QuestionHandler Instance;
    public static List<Question> questionList;

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

    private void OnEnable()
    {
        MainMenuController.gameLoaded += SetGameQuestions;
    }

    private void OnDisable()
    {
        MainMenuController.gameLoaded -= SetGameQuestions;
    }

    private void SetGameQuestions()
    {
        CreateQuestionPool();
        questionList = gameQuestions;
    }

    private void CreateQuestionPool()
    {
        int randomIndex;
        {
            do
            {
                randomIndex = rand.Next(1, availableQuestions.Count);
                if (!gameQuestions.Contains(availableQuestions[randomIndex]))
                {
                    gameQuestions.Add(availableQuestions[randomIndex]);
                }
            }
            while (gameQuestions.Count < gameLength);
        }
    }
}
