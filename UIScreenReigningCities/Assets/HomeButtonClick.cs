using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeButtonClick : MonoBehaviour
{
    public void OnHomeButtonClick()
    {
        //FindObjectOfType<AudioManager>().PlaySound("ButtonSound");
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }
}
