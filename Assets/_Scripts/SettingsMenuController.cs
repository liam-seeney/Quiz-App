using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenuController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _resetScoreText;
    [SerializeField] private Button _resetScoreButton;
    [SerializeField] private ScoreController _newScore;

    public void ResetScore()
    {
        _newScore.SetScore(0);
        SaveController.SaveGameData(_newScore);
        _resetScoreText.text = "Done!";
        _resetScoreButton.interactable = false;
    }
}
