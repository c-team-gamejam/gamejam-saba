using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[CreateAssetMenu]
[System.Serializable]
public class ChapterData : ScriptableObject
{
    public List<Chapter> ChapterDataList;

    [System.Serializable]
    public class Chapter
    {
        public Title Title;
        public float RequiredDHA;
        [TextArea(1, 5)] public List<string> MainScript;
        [TextArea(1, 5)] public List<string> GoodPatternScript;
        [TextArea(1, 5)] public List<string> BadPatternScript;
        public Sprite StoryBackground;
        public GameObject Saba;
    }
}

[Flags]
public enum Title
{
    One = 1,
    Two = 2,
    Three = 4,
    Seven = 8,
    Four = 16,
    BadEnd = 32,
    NormalEnd = 64,
    TrueEnd = 128,
    Prologue = 256,
}
