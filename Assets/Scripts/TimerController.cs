using System;
using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    public static event Action timeRanOut;

    [SerializeField] private TextMeshProUGUI timerText;

    private float timer = 7;
    private bool isAnswering = true;

    private void OnEnable()
    {
        QuizMain.hasAnswered += resetTimer;
    }

    private void OnDisable()
    {
        QuizMain.hasAnswered -= resetTimer;
    }
    private void Update()
    {
        if (isAnswering)
        {
            timer -= Time.deltaTime;
            updateTimeRemaining();

            if (timer < 0)
            {
                timeRanOut?.Invoke();
                isAnswering = false;
            }
        }
    }

    private void updateTimeRemaining()
    {
        timerText.text = Mathf.Round(timer).ToString();
    }

    private void resetTimer(bool isAnsweringSent)
    {
        timer = 7;
        isAnswering = isAnsweringSent;
    }
}
