using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyResourcesButtonClick : MonoBehaviour
{
    public void OnButtonClick()
    {
        FindObjectOfType<AudioManager>().PlaySound("ButtonSound");
        AndroidJavaClass UPJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject activityJavaObj = UPJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
        activityJavaObj.Call("startMaps", "http://romps.com.au:3000/rcmap/?latitude=-34.427811&longitude=150.893066");
    }
}
