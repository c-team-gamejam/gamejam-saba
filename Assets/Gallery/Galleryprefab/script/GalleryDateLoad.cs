using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalleryDateLoad : MonoBehaviour {
    SaveData Load;
	// Use this for initialization
	void Start () {
        SaveData Load =SaveData.Instance;
        Load.Reload();
    }
	
	// Update is called once per frame
	void Loader () {
        
	}

    void sapmle()
    {
        //var chapter = Chapter
        //if()
    }
}
