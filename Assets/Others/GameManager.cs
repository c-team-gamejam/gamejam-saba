using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    public ChapterData ChapterData
    {
        get
        {
            return chapterData;
        }
    }
    public Chapter currentChapter { get; set; }

    [SerializeField] ChapterData chapterData;

    private void Awake()
    {
        SceneManager.sceneLoaded += ((scene, mode) => {
            SceneFader.Instance.FadeIn(1f);
        });
    }
}
