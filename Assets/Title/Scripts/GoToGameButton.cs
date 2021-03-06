﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToGameButton : MonoBehaviour
{
    SceneFader sceneFader;
    [SerializeField] float fadingTime = 3f;

    private void Awake()
    {
        sceneFader = SceneFader.Instance;
    }

    public void FadeToGameScene()
    {
        sceneFader.FadeOut(SceneFader.SceneTitle.GameScene, fadingTime);
    }
    public void FadeToGalleryScene()
    {
        sceneFader.FadeOut(SceneFader.SceneTitle.GalleryScene, fadingTime);
    }

}
