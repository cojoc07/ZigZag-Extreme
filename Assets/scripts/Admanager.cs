using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using admob;

public class Admanager : MonoBehaviour {

	public static Admanager Instance { set; get; }

    public string bannerId = "ca-app-pub-3206936300804750/6808775422";
    public string videoId = "ca-app-pub-3206936300804750/9762241829";

    private void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);

        Admob.Instance().initAdmob(bannerId, videoId);

        //folosim set testing pt a afisa o reclama dummy
        Admob.Instance().setTesting(true);
        Admob.Instance().loadInterstitial();
    }

    public void ShowBanner()
    {
        Admob.Instance().showBannerRelative(AdSize.Banner, AdPosition.TOP_CENTER, 5);
    }

    public void ShowVideo()
    {
        if (Admob.Instance().isInterstitialReady())
        {
            Admob.Instance().showInterstitial();
        }
    }
}
