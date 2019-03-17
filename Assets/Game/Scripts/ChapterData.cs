using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu]
[System.Serializable]
public class ChapterData : ScriptableObject
{
    public List<ChapterInfo> ChapterDataList;

    [System.Serializable]
    public class ChapterInfo
    {
        public Chapter Title ;
        public float RequiredDHA;
        [TextArea(1,5)] public List<string> TextResourses;
    }
}

[Flags]
public enum Chapter
{
    One,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
}
