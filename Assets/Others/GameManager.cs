using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
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
    int count;
    float startTime;

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

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var pointerEventData = new PointerEventData(EventSystem.current)
            {
                position = Input.mousePosition
            };
            var raycastResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerEventData, raycastResults);
            if (raycastResults.Count == 0) return;
            var resultGameObject = raycastResults[0].gameObject; // 最初に検出したオブジェクトを代入する
            if (resultGameObject != null)
            {
                Debug.Log(resultGameObject.name);
            }
        }

        if(startTime == 0)
        {
            startTime = Time.time;
        }

        if (Time.time - startTime <= 1)
        {
            ++count;
        }
        else
        {
            Debug.Log(string.Format("flame rate is {0}", count));
            count = 0;
            startTime = 0;
        }
    }

    public override void OnInitialize()
    {
        base.OnInitialize();
        DontDestroyOnLoad(gameObject);
    }

    public ChapterData.Chapter GetChapter(Title title)
    {
        return chapterData.ChapterDataList.Find((chapter) => chapter.Title == title);
    }
}
public enum Pattern
{
    Good,
    Bad,
}
