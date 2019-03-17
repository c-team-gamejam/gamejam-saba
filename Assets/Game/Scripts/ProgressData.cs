using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProgressData: MonoBehaviour
{
    public Chapter ChapterProgress{ get; set; }



    /// <summary>
    /// saveする
    /// </summary>
    public void SavingStoryProgress(Chapter chapter)
    {
        ChapterProgress = ChapterProgress | chapter;
    }
}
