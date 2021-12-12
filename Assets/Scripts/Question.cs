using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Question")]
public class Question : ScriptableObject
{
    [SerializeField] private int questionNumber;

    [TextArea(5, 10)]
    [SerializeField] private string questionText;
    [SerializeField] private string[] answers = new string[4];
    [SerializeField] private int correctAnswerIndex;

    public string GetQuestion()
    {
        return questionText;
    }

    public string GetAnswers(int index)
    {
        return answers[index];
    }

    private int GetCorrectAnswerIndex()
    {
        return correctAnswerIndex;
    }
}
