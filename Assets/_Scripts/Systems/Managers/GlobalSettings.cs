using UnityEngine;

public class GlobalSettings : MonoBehaviour
{
    public static GlobalSettings instance;
    private bool gameMuted;

    private void Awake()
    {
        if (!instance)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {

    }
}
