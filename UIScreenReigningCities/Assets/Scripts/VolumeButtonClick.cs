using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeButtonClick : MonoBehaviour
{
    private bool isMuted;
    public Button button;
    public Sprite volumeON;
    public Sprite mute;
    public AudioSource m_MyAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        isMuted = false;
      
    }

    public void MutePressed()
    {
        isMuted = !isMuted;
        if (isMuted)
        {
            m_MyAudioSource.Stop();
            button.GetComponent<Image>().sprite = mute;
        }
        else
        {
            m_MyAudioSource.Play();
            button.GetComponent<Image>().sprite = volumeON;
        }
    }
}
