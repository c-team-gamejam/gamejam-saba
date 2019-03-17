using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneFadeButton : MonoBehaviour
{
    SceneFader sceneFader;
    [SerializeField] SceneFader.SceneTitle fadingTitle;
    [SerializeField] SceneFader.FadeColor fadeColor;
    [SerializeField] float fadingTime = 1f;
    private void Awake()
    {
        sceneFader = SceneFader.Instance;
    }

    public void FadingOut()
    {
        sceneFader.FadeOut(fadingTitle, fadingTime, fadeColor);
    }
}
