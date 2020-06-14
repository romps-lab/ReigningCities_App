using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip buttonSound;
    public void onClickSound()
    {
        audioSource.PlayOneShot(buttonSound);
    }
}
