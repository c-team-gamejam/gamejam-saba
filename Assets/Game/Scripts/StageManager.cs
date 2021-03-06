﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StageManager : MonoSingleton<StageManager>
{
    SaveData saveData;
    StateManager stateManager;
    GameManager gameManager;
    TouchGestureDetector touchGestureDetector;


    [SerializeField] ChapterData chapterData;
    [SerializeField] UIManager uIManager;
    [SerializeField] AudioSource bGM;
    [SerializeField] GameObject sabaPosition;

    [Header("Parameters")]
    [SerializeField] float delayTime = 2f;
    [SerializeField] float fadingTime = .5f;

    GameObject saba;
    float requiredDHA;
    float currentDHA;



    private void Awake()
    {
        stateManager = StateManager.Instance;
        gameManager = GameManager.Instance;
        touchGestureDetector = TouchGestureDetector.Instance;




        stateManager.m_StateMachineEvent.AddListener((state) =>
        {
            switch (state)
            {
                case StateManager.StateMachine.State.InitGame:
                    InitializeStage();
                    break;
                case StateManager.StateMachine.State.InTheGame:
                    break;
                case StateManager.StateMachine.State.NextStory:
                    break;
                case StateManager.StateMachine.State.Pause:
                    break;
                default:
                    break;
            }
        });
    }

    private void Start()
    {
        touchGestureDetector.onGestureDetected.AddListener((gesture, touchInfo) =>
        {
            switch (gesture)
            {
                case TouchGestureDetector.Gesture.TouchBegin:
                case TouchGestureDetector.Gesture.Click:
                    {
                        GameObject go;
                        var result = touchInfo.HitDetection(out go);
                        if (result && stateManager.m_StateMachine.m_State == StateManager.StateMachine.State.InTheGame)
                        {
                            DetectedObjectDistinction(go);
                        }
                    }
                    break;
                default:
                    break;
            }
        });
    }

    void DetectedObjectDistinction(GameObject go)
    {
        switch (go.tag)
        {
            case "DHA":
                OnTouchedDHA(go);
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// ポイントを加算する.もし一定値に達したらストーリーシーンに遷移する
    /// </summary>
    /// <param name="go"></param>
    void OnTouchedDHA(GameObject go)
    {
        var dha = go.GetComponent<DHA>();

        dha.Play();
        currentDHA += dha.point;
        uIManager.SyncProgress(requiredDHA, currentDHA);

        if (currentDHA >= requiredDHA)
        {
            stateManager.TransitionState(StateManager.StateMachine.State.NextStory);
            uIManager.DisplayClearText();
            Invoke("FadingStoryScene", delayTime);
        }
        Destroy(go);
    }

    void FadingStoryScene()
    {
        SceneFader.Instance.FadeOut(SceneFader.SceneTitle.StoryScene, fadingTime, SceneFader.FadeColor.White);
    }

    /// <summary>
    /// セーブをロードし,現在のHDA数やチャプター,そのチャプターに応じた必要DHA数を取得
    /// </summary>
    void InitializeStage()
    {
        saveData = SaveData.Instance;
        var chapter = gameManager.CurrentChapter;
        requiredDHA = chapter.RequiredDHA;
        currentDHA = saveData.currentDHA;

        var sabaObject = chapter.Saba;
        var go = Instantiate(sabaObject, sabaPosition.transform);
        go.transform.localPosition = Vector3.zero;

        bGM.Play();
        // event call
        stateManager.TransitionState(StateManager.StateMachine.State.InTheGame);
    }
}
