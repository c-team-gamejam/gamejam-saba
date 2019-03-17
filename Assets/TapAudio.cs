using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapAudio : MonoBehaviour {
    [SerializeField] AudioSource audioSource;
    public void TapBGM()
    {
        audioSource.Play();
    }
}
