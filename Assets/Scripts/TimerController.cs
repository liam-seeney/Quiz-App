using System;
using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    public static event Action TimeRanOut;
    public static event Action<float> TimeRemaining;

    [SerializeField] private TextMeshProUGUI timerText;

    [SerializeField] private float timer = 7;
    private bool isAnswering = true;

    private void OnEnable()
    {
        QuizMain.hasAnswered += resetTimer;
        QuizMain.stopTheTimer += StopTheTimer;
    }

    private void OnDisable()
    {
        QuizMain.hasAnswered -= resetTimer;
        QuizMain.stopTheTimer -= StopTheTimer;
    }
    private void Update()
    {
        if (isAnswering)
        {
            timer -= Time.deltaTime;
            updateTimeRemaining();

            if (timer < 0)
            {
                TimeRanOut?.Invoke();
                isAnswering = false;
            }
        }
    }

    private void StopTheTimer()
    {
        isAnswering = false;
        TimeRemaining?.Invoke(timer);
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
