using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Dialogue
/// </summary>
public class DialogueSystem : MonoBehaviour
{
    /// <summary></summary>
    [SerializeField] Text textBox;
    /// <summary></summary>
    [SerializeField] float waitTimeOfDisplay = 0.5f;
    /// <summary></summary>
    [SerializeField] List<Button> ButtonList;



    IEnumerator TextDisplay(List<string> textSctipt)
    {
        foreach (var text in textSctipt)
        {
            //ContinueTrigger = false;
            textBox.text = "";
            foreach (var character in text)
            {
                textBox.text += character;
                yield return new WaitForSeconds(waitTimeOfDisplay);
            }
            //yield return new WaitUntil(() => ContinueTrigger);
        }
    }

    [Flags]
    public enum DialogFlags
    {
        None = 1,
        Continue = 2,
        Skip = 4,
    }
}
