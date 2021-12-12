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
    private Color selectedColor = new Color32(54, 255, 45, 255);
    private Color defaultColor = new Color32(255, 255, 255, 255);

    private void Start()
    {
        GetRandomIndex();
        SetQuestionText();
    }

    private void GetRandomIndex()
    {
        int randomIndex = Random.Range(0, questions.Count);
        question = questions[randomIndex];
        questions.RemoveAt(randomIndex);
    }

    private void SetQuestionText()
    {
        questionTextArea.text = question.GetQuestionText();
        SetAnswerButtons();
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
            SetButtonColour(index);
        }
        else
        {
            questionTextArea.text = $"Wrong!\n The correct answer is:\n {question.GetAnswers(question.GetCorrectAnswerIndex())}";
            SetButtonColour(question.GetCorrectAnswerIndex());
        }

        StartCoroutine(LoadNextQuestion());
    }

    private void SetButtonColour(int index)
    {
        Image button = answerButtons[index].GetComponent<Image>();
        button.color = selectedColor;
    }

    private void SetButtonState(bool state)
    {
        for (int i = 0; i < answerButtons.Count; i++)
        {
            {
                Button button = answerButtons[i].GetComponent<Button>();
                button.interactable = state;
            }
        }
    }

    private IEnumerator LoadNextQuestion()
    {
        yield return new WaitForSeconds(2f);
        SetButtonState(true);
        SetDefaultButtonColors();
        GetRandomIndex();
        SetQuestionText();
    }

    private void SetDefaultButtonColors()
    {
        for (int i = 0; i < answerButtons.Count; i++)
        {
            Image buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.color = defaultColor;
        }
    }
}
