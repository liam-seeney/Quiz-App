using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

        SetQuestionText();
        SetAnswerButtons();
    }

    private void SetQuestionText()
    {
        questionTextArea.text = question.GetQuestionText();
    }

    private void SetAnswerButtons()
    {
        for (int i = 0; i < answerButtons.Count; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswers(i);
        }
    }

    public void AnswerSelected(int index)
    {
        SetButtonState(false);
        if (index == question.GetCorrectAnswerIndex())
        {
            questionTextArea.text = "Correct!";
        }
        else
        {
            questionTextArea.text = $"Wrong! The correct answer is:\n {question.GetAnswers(question.GetCorrectAnswerIndex())}";
        }
    }

    private void SetButtonState(bool state)
    {
        for (int i = 0; i < answerButtons.Count; i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }
}
