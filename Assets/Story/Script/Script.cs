using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

[Serializable]
public class Script : MonoBehaviour
{
    [SerializeField] string words;
    [SerializeField] Image tex;

    public Image Tex { get => tex; set => tex = value; }
    public string Words { get => words; set => words = value; }
}