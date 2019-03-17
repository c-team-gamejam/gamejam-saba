using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalleryDateLoad : MonoBehaviour
{
    SaveData saveData;
    int flagScore;
    public bool Trueend;
    public bool Normalend;
    public bool Badend;
    // Use this for initialization
    void Start()
    {
        saveData = SaveData.Instance;
        GalleryLoader();
        saveData.Reload();
        Trueend = false;
        Normalend = false;
        Badend = false;
    }

    // Update is called once per frame
    public void GalleryLoader()
    {
        //var myFlag = saveData.ChapterProgress;
        var myFlag = Chapter.NormalEnd;

        if (myFlag == (myFlag | Chapter.BadEnd))
        {
            Badend = true;
        }
        if (myFlag == (myFlag | Chapter.TrueEnd))
        {
            Normalend = true;
        }
        if (myFlag == (myFlag | Chapter.NormalEnd))
        {
            Trueend = true;
        }

    }


}
