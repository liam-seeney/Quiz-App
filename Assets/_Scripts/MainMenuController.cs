using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public static event Action gameLoaded;
    public static event Action buttonPressed;

    private ScoreController scoreController;

    private void Start()
    {
        scoreController = FindObjectOfType<ScoreController>();
    }

    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();

                return;
            }
        }
    }

    public void LoadGame()
    {
        buttonPressed?.Invoke();
        gameLoaded?.Invoke();
        Destroy(scoreController);
        SceneManager.LoadScene("Main");
    }

    public void SettingsMenu()
    {
        SceneManager.LoadScene("SettingsMenu");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
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
