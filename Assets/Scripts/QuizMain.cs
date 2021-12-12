using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuizMain : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questionTextArea;
    [SerializeField] private List<Question> questions;
    [SerializeField] private List<GameObject> answerButtons;

    private Question question;

    private void Start()
    {
        question = questions[Random.Range(0, questions.Count)];
        GetFirstQuestion();
        SetAnswerButtons();
    }

    private void GetFirstQuestion()
    {
        questionTextArea.text = question.GetQuestion();
    }

    private void SetAnswerButtons()
    {
        for (int i = 0; i < answerButtons.Count; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswers(i);
        }
    }
}
