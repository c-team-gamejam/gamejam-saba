using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    public ChapterData ChapterData => chapterData;

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

    private void Awake()
    {
        SceneManager.sceneLoaded += ((scene, mode) =>
        {
            SceneFader.Instance.FadeIn(1f);
        });
    }
    public override void OnInitialize() => DontDestroyOnLoad(gameObject);
    public ChapterData.Chapter GetChapter(Title title) => chapterData.ChapterDataList.Find((chapter) => chapter.Title == title);
}
public enum Pattern
{
    Good,
    Bad,
}
