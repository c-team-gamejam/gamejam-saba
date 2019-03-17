using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DHA : MonoBehaviour
{
    [SerializeField] public int point = 1;

    public void Play()
    {
        var audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
}
