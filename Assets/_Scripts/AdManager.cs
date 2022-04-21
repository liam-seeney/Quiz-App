using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour
{
    private void Start()
    {
        ShowBanner();
    }

    private void ShowBanner()
    {
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show("Banner_Android");
    }
}
