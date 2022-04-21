using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip clickSFX;
    [SerializeField] private AudioSource audioSource;

    private void OnEnable()
    {
        QuizMain.buttonPressed += PlayClickSound;
        MainMenuController.buttonPressed += PlayClickSound;
    }

    private void OnDisable()
    {
        QuizMain.buttonPressed -= PlayClickSound;
        MainMenuController.buttonPressed -= PlayClickSound;
    }

    private void PlayClickSound()
    {
       audioSource.PlayOneShot(clickSFX);
    }
}
