using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[CreateAssetMenu]
[System.Serializable]
public class ChapterData : ScriptableObject
{
    public List<ChapterInfo> ChapterDataList;

    [System.Serializable]
    public class ChapterInfo
    {
        public Chapter Title;
        public float RequiredDHA;
        [TextArea(1, 5)] public List<string> TextResourses;
        [TextArea(1, 5)] public List<string> YesPatternText;
        [TextArea(1, 5)] public List<string> NoPatternText;
        public Image StoryBackground;
        public Image Saba;
    }
}

[Flags]
public enum Chapter
{
    One = 1,
    Two = 2,
    Three = 4,
    Four = 8,
    Five = 16,
    Six = 32,
    Seven = 64,
    BadEnd = 128,
    NormalEnd = 256,
    TrueEnd = 512,
}
