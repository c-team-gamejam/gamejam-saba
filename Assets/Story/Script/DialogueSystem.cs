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
    /// <summary>ダイアログ開始時</summary>
    public event Action OnEnter = () => { };
    /// <summary>ダイアログ終了時</summary>
    public event Action OnExit = () => { };
    /// <summary>ダイアログ中のイベント発生時</summary>
    public event Action OnEnterEvent = () => { };
    /// <summary>ダイアログ中のイベント終了時</summary>
    public event Action OnExitEvent = () => { };

    public bool isPlayingDialogue { get; set; }

    /// <summary></summary>
    [SerializeField] Text textBox;
    /// <summary></summary>
    [SerializeField] float waitTimeOfDisplay = 0.5f;
    /// <summary></summary>
    [SerializeField] List<Button> buttonList;


    public void DisplayText(List<string> script)
    {
        if (isPlayingDialogue)
        {
            return;
        }
        StartCoroutine(TextAnimation(script));
    }

    IEnumerator TextAnimation(List<string> textSctipt)
    {
        OnEnter?.Invoke();
        isPlayingDialogue = true;
        foreach (var text in textSctipt)
        {
            //ContinueTrigger = false;
            textBox.text = "";
            foreach (var character in text)
            {
                textBox.text += character;
                yield return new WaitForSeconds(waitTimeOfDisplay);
            }
            isPlayingDialogue = false;

            if (TextManager.Instance.TargetSubject == TextManager.Subject.Main)
            {
                OnEnterEvent?.Invoke();
                TextManager.Instance.PlayStory(TextManager.Subject.Choice);
            }
        }
        OnExit?.Invoke();
    }

    public void CallbackExitEvent()
    {
        OnExitEvent?.Invoke();
    }

    [Flags]
    public enum DialogFlags
    {
        None = 1,
        HasNext = 2,
        Selection = 4,
    }
}
