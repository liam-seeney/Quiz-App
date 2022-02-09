using UnityEngine;
using System;
using System.Collections.Generic;

public class QuestionHandler : MonoBehaviour
{
    [SerializeField] private List<Question> availableQuestions;

    private List<Question> gameQuestions = new List<Question>();
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
        while (gameQuestions.Count < 5)
        {
            randomIndex = rand.Next(1, availableQuestions.Count);
            gameQuestions.Add(availableQuestions[randomIndex]);
            availableQuestions.RemoveAt(randomIndex);
        }
    }
}
