using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;


public class AdBanner : MonoBehaviour
{

    //string AdUnitID = "ca-app-pub-7121838771446885~4925473176";//원 광고
    string AdUnitID = "ca-app-pub-3940256099942544/6300978111";//테스트 광고


    // string AdUnitID = "unDefind";

    BannerView banner;
    AdRequest request;

    static bool isAdsBannerSet = false;


    // Use this for initialization

    void Start()
    {
        if (!isAdsBannerSet)
            RequestBanner();
    }



    private void RequestBanner()

    {


        banner = new BannerView(AdUnitID, AdSize.Banner, AdPosition.Bottom);
        // AdRequest request = new AdRequest.Builder().Build();//정식 빌드 기기
        request = new AdRequest.Builder().AddTestDevice(AdRequest.TestDeviceSimulator).AddTestDevice("0D9676C8F467F0B3").Build();//테스트 기기

        banner.LoadAd(request);
        banner.Show();

        isAdsBannerSet = true;

    }

}