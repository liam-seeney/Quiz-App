using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameOverTextField;

    private ScoreController scoreController;

    void Start()
    {
        scoreController = FindObjectOfType<ScoreController>();

        gameOverTextField.text = $"You have finished the quiz!\nYour score is:\n{scoreController.GetScore()}";
    }
}
