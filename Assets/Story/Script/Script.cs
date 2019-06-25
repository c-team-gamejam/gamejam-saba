using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Script : MonoBehaviour
{
    private string words;
    private Image tex;
    private float animationSpeed;

    public float AnimationSpeed { get => animationSpeed; set => animationSpeed = value; }
    public Image Tex { get => tex; set => tex = value; }
    public string Words { get => words; set => words = value; }

}
