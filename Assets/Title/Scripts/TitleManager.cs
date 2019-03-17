using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
   [SerializeField] AudioManager audioManager;

    private void Start()
    {
        audioManager.Play();
    }
    void TapBGM()
    {
        audioManager.Play();
    }
}