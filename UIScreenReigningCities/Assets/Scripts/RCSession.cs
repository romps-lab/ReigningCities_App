using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RCSession : MonoBehaviour
{

    private string playerEmail;
    private string playerResourceConfig;
    private string RCStoreConfig;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        playerSignin();
        RCStoreConfig = RCApiEndpoint.Instance.fetchGameStoreConfig();
        setupStore();
        //get player resource inside update
    }

    private void Update()
    {
        //wait untill we get callback from platform .... must add some timing stuff and abort
        if (playerEmail != null && playerResourceConfig == null)
        {
            Debug.Log("Email : " + playerEmail);
            playerResourceConfig = RCApiEndpoint.Instance.fetchPlayerResourceConfig("rppdighe4892@gmail.com");
            setupPlayerResources();
            //RCApiEndpoint.Instance.updatePlayerEntities();
        }
    }

    public void playerSignin()
    {
        AndroidJavaClass UPJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject activityJavaObj = UPJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
        activityJavaObj.Call<string>("googleSignin");
    }

    public void setupStore()
    {
        if(RCStoreConfig == null) { return; }
        RCStore.Instance.setupStore(RCStoreConfig);
    }

    public void setupPlayerResources()
    {
        if (playerResourceConfig == null) { return; }
        Player.Instance.setupPlayerResources(playerResourceConfig);
    }

    public void setEmail(string email)
    {
        this.playerEmail = email;
        Player.Instance.setEamil(this.playerEmail);
    }

}
