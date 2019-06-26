using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Dialogue
/// </summary>
public class DialogueSystem : MonoSingleton<DialogueSystem>
{
    #region Properties
    /// <summary>ダイアログ開始時</summary>
    public event Action OnEnter = () => { };
    /// <summary>ダイアログ終了時</summary>
    public event Action OnExit = () => { };
    /// <summary>ダイアログ中のイベント発生時</summary>
    public event Action OnEnterEvent = () => { };
    /// <summary>ダイアログ中のイベント終了時</summary>
    public event Action OnExitEvent = () => { };
    /// <summary>疑似Switch. trueを代入した後、一回だけgetでtrueを返すようにする</summary>
    public bool EventSwitch
    {
        get
        {
            if (eventFlag)
            {
                eventFlag = false;
                return true;
            }
            return false;
        }
        set => eventFlag = value;
    }
    /// <summary></summary>
    public bool IsPlayingDialogue { get; set; }
    #endregion
    #region Variables
    [SerializeField] Text textBox;
    [SerializeField] List<Button> buttonList;
    [SerializeField] float eachWaitTimeOfCharacter = 0.25f;

    GameManager gm;
    ChapterData.Chapter targetChapter;
    bool eventFlag;
    #endregion
    #region Methods
    public void PlayDialogue()
    {
        
    }
    public void SetActiveEventSwitch(bool isActive) => EventSwitch = isActive;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="scripts"></param>
    public void DisplayText(List<Script> scripts)
    {
        if (IsPlayingDialogue) throw new InvalidOperationException($"今DisplayTextは呼ばれるべきではない.");
        StartCoroutine(TextAnimation(scripts));
    }
    /// <summary>
    /// テキストアニメーション
    /// </summary>
    /// <param name="scripts"></param>
    /// <returns></returns>
    IEnumerator TextAnimation(List<Script> scripts)
    {
        OnEnter?.Invoke();
        IsPlayingDialogue = true;
        foreach (var script in scripts)
        {
            //ContinueTrigger = false;
            textBox.text = "";
            foreach (var character in script.Words)
            {
                textBox.text += character;
                yield return new WaitForSeconds(eachWaitTimeOfCharacter);
            }
            yield return new WaitUntil(() =>
            {
                Debug.Log("Check event");
                return EventSwitch;
            });
        }
        IsPlayingDialogue = false;
        OnExit?.Invoke();
    }
    #endregion
    #region Callbacks
    private void Awake()
    {
        gm = GameManager.Instance;
    }
    private void Start()
    {
        targetChapter = gm.CurrentChapter;
    }
    #endregion
    #region Enums
    [Flags]
    public enum DialogFlags
    {
        None = 1,
        HasNext = 2,
        Selection = 4,
    }
    public enum Subject
    {
        Main,
        Choice,
        Good,
        Bad,
    }
    #endregion
}