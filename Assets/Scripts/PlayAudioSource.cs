using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioSource : MonoBehaviour
{
    public AudioSource playingAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        PlayAudio();
    }

    public void PlayAudio()
    {
        playingAudioSource.Play();
    }
}
