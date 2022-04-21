using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Question")]
public class Question : ScriptableObject
{
    [TextArea(5, 10)]
    [SerializeField] private string questionText;
    [SerializeField] private string[] answers = new string[4];
    [SerializeField] private int correctAnswerIndex;

    public string GetQuestionText()
    {
        return questionText;
    }

    public string GetAnswers(int index)
    {
        return answers[index];
    }

    public int GetCorrectAnswerIndex()
    {
        return correctAnswerIndex;
    }
}
