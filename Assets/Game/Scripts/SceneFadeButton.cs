using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneFadeButton : MonoBehaviour
{
    SceneFader sceneFader;
    [SerializeField] SceneFader.SceneTitle fadingTitle;
    [SerializeField] float fadingTime = 3f;
    private void Awake()
    {
        sceneFader = SceneFader.Instance;
    }

    public void FadingOut()
    {
        sceneFader.FadeOut(fadingTitle, fadingTime);
    }
}
