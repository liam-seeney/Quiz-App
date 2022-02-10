using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public static event Action gameLoaded;

    private ScoreController scoreController;

    private void Start()
    {
        scoreController = FindObjectOfType<ScoreController>();
    }

    public void LoadGame()
    {
        gameLoaded?.Invoke();
        Destroy(scoreController);
        SceneManager.LoadScene("Main");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif

    }
}
