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
        public GameObject Saba;
    }
}

[Flags]
public enum Chapter
{
    One = 1,
    Two = 2,
    Three = 4,
    Seven = 8,
    Four = 16,
    BadEnd = 32,
    NormalEnd = 64,
    TrueEnd = 128,
}
