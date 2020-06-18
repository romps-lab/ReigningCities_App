using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClickSound : MonoBehaviour
{
    public void OnButtonClick()
    {
        FindObjectOfType<AudioManager>().PlaySound("ButtonSound");
    }

    public void DeployButtonScreenChange()
    {
        SceneManager.LoadScene("LoadStore", LoadSceneMode.Single);
    }

    public void OtherResourcesButtonScreenChange()
    {
        SceneManager.LoadScene("DeployScene", LoadSceneMode.Single);
    }

}
