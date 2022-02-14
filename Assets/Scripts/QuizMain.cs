using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class QuizMain : MonoBehaviour
{
    public static event Action<bool> hasAnswered;
    public static event Action stopTheTimer;

    [SerializeField] private TextMeshProUGUI questionTextArea;
    [SerializeField] private List<GameObject> answerButtons;
    [SerializeField] private ScoreController scoreController;

    private Question question;

    private Color selectedColor = new Color32(54, 255, 45, 255);
    private Color defaultColor = new Color32(255, 255, 255, 255);
    private float waitTime = 1.5f;
    private System.Random random = new System.Random();

    private void OnEnable()
    {
        TimerController.TimeRanOut += outOfTime;
    }

    private void OnDisable()
    {
        TimerController.TimeRanOut -= outOfTime;
    }

    private void Start()
    {
        GetRandomIndex();
        SetQuestionText();
    }

    private void GetRandomIndex()
    {
        int randomIndex = UnityEngine.Random.Range(0, QuestionHandler.questionList.Count);
        question = QuestionHandler.questionList[randomIndex];
        QuestionHandler.questionList.RemoveAt(randomIndex);
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
        stopTheTimer?.Invoke();
        SetButtonState(false);

        if (index == question.GetCorrectAnswerIndex())
        {
            questionTextArea.text = "Correct!";
            SetButtonColour(index);
            scoreController.IncrementScore();
        }
        else
        {
            questionTextArea.text = $"Wrong!\nThe correct answer is:\n{question.GetAnswers(question.GetCorrectAnswerIndex())}";
            SetButtonColour(question.GetCorrectAnswerIndex());
        }

        StartCoroutine(LoadNextQuestion());
    }

    private void outOfTime()
    {
        SetButtonState(false);
        questionTextArea.text = $"Times Up!\nThe correct answer is:\n{question.GetAnswers(question.GetCorrectAnswerIndex())}";
        SetButtonColour(question.GetCorrectAnswerIndex());
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
        scoreController.DisplayScore();

        if (QuestionHandler.questionList.Count > 0)
        {
            yield return new WaitForSeconds(waitTime);
            SetButtonState(true);
            SetDefaultButtonColors();
            GetRandomIndex();
            SetQuestionText();
            hasAnswered?.Invoke(true);
        }
        else
        {
            yield return new WaitForSeconds(waitTime);
            SceneManager.LoadScene("GameOver");
        }
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
