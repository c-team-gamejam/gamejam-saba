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
    public List<ChoiceMaterial> choiceMaterials;

    [System.Serializable]
    public class Chapter
    {
        public Title Title;
        public float RequiredDHA;
        [TextArea(1, 5)] public List<Script> MainScript;
        [TextArea(1, 5)] public List<Script> GoodPatternScript;
        [TextArea(1, 5)] public List<Script> BadPatternScript;
        [TextArea(1, 5)] public List<Script> ChoiceScript;
        public Sprite StoryBackground;
        public GameObject Saba;
    }
}

[Serializable]
public class ChoiceMaterial
{
    Title title;
    public List<string> choiceScript;
    int index;
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
