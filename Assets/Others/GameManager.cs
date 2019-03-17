using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] ChapterData chapterData;
    Chapter currentChapter;

    private void Awake()
    {
        SceneManager.sceneLoaded += ((scene, mode) => { }        );
    }
}
