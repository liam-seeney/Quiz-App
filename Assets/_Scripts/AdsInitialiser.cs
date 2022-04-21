using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInitialiser : MonoBehaviour, IUnityAdsInitializationListener
{
    private string _androidGameId = "4615735";
    private string _iOSGameId = "4615734";
    private string _gameId;

    [SerializeField] private bool _testMode = true;

    private void Awake()
    {
        InitializeAds();
    }

    public void InitializeAds()
    {
        _gameId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOSGameId
            : _androidGameId;
        Advertisement.Initialize(_gameId, _testMode, this);
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }
}