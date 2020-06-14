using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignIn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AndroidJavaClass UPJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject activityJavaObj = UPJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
        activityJavaObj.Call<string>("googleSignin");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
