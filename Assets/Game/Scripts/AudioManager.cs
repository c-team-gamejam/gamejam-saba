using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    public void Play()
    {
        audioSource.Play();
    }

    public void Stop()
    {
        iTween.AudioTo(gameObject.gameObject, iTween.Hash("volume", 0f));
    }
}
