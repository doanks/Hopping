using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class GoogleAds : MonoBehaviour {

	public static GoogleAds instance;

	public BannerView bannerView;
	public InterstitialAd interstitial;
	public NativeExpressAdView native;

	void Awake () {
		if (instance == null)
			instance = this;
		else {
			Destroy (gameObject);
			return;
		}

		DontDestroyOnLoad(gameObject);
	}

	public void RequestBanner()
	{
		#if UNITY_ANDROID
		string adUnitId = "ca-app-pub-1999310074725098/5081825272";
		#elif UNITY_IPHONE
		string adUnitId = "INSERT_IOS_BANNER_AD_UNIT_ID_HERE";
		#else
		string adUnitId = "unexpected_platform";
		#endif

		// Create a 320x50 banner at the top of the screen.
		BannerView bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();
		// Load the banner with the request.
		bannerView.LoadAd(request);
	}

	public void RequestInterstitial()
	{
		#if UNITY_ANDROID
		string adUnitId = "ca-app-pub-1999310074725098/6676487282";
		#elif UNITY_IPHONE
		string adUnitId = "INSERT_IOS_INTERSTITIAL_AD_UNIT_ID_HERE";
		#else
		string adUnitId = "unexpected_platform";
		#endif

		// Initialize an InterstitialAd.
		interstitial = new InterstitialAd(adUnitId);
		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();
		// Load the interstitial with the request.
		interstitial.LoadAd(request);
	}

	public void ShowInterstitial(){
		if (interstitial.IsLoaded()){
			interstitial.Show();
		}
	}
}
