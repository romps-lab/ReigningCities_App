using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyResourcesButtonClick : MonoBehaviour
{
    public void OnButtonClick()
    {
        FindObjectOfType<AudioManager>().PlaySound("ButtonSound");
    }
}
