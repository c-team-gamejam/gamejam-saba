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

    int GoodCount;
    int BadCount;

    public void AddPatternCount(Pattern pattern)
    {
        switch (pattern)
        {
            case Pattern.Good:
                GoodCount++;
                break;
            case Pattern.Bad:
                BadCount++;
                break;
            default:
                break;
        }
    }

    private void Awake()
    {
        SceneManager.sceneLoaded += ((scene, mode) =>
        {
            SceneFader.Instance.FadeIn(1f);
        });
    }

    public override void OnInitialize()
    {
        base.OnInitialize();
        DontDestroyOnLoad(gameObject);
    }
}
public enum Pattern
{
    Good,
    Bad,
}
