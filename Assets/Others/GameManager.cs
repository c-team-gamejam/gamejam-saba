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

    public ChapterData.Chapter CurrentChapter
    {
        get
        {
            var saveData = SaveData.Instance;
            Debug.Log(saveData.ChapterProgress);
            var cChapter = chapterData.ChapterDataList.Find((chapter) => chapter.Title == saveData.CurrentChapter);
            return cChapter;
        }
    }


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
