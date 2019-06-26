//using UnityEngine;
//using System.Collections;

//public class TextManager : MonoSingleton<TextManager>
//{
//    public Subject TargetSubject { get; set; }

//    TouchGestureDetector tgd;
//    ChapterData.Chapter chapter;
//    DialogueSystem dialogueSystem;
//    GameManager gm;


//    private void Awake()
//    {
//        dialogueSystem = DialogueSystem.Instance;
//        tgd = TouchGestureDetector.Instance;
//        gm = GameManager.Instance;

//        dialogueSystem.OnExit += () =>
//        {
//            SceneFader.Instance.FadeOut(SceneFader.SceneTitle.GameScene);
//        };
//    }

//    private void Start()
//    {
//        chapter = gm.GetChapter(Title.One);
//        PlayStory(Subject.Main);
//    }

//    public void PlayStory(Subject sub)
//    {
//        switch (sub)
//        {
//            case Subject.Main:
//                dialogueSystem.DisplayText(chapter.MainScript);
//                break;
//            case Subject.Good:
//                dialogueSystem.DisplayText(chapter.GoodPatternScript);
//                break;
//            case Subject.Bad:
//                dialogueSystem.DisplayText(chapter.BadPatternScript);
//                break;
//            case Subject.Choice:
//                break;
//            default:
//                break;
//        }
//    }



//}
