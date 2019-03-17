using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalleryDateLoad : MonoBehaviour {
    SaveData Load;
    int flagScore;
	// Use this for initialization
	void Start () {
        SaveData Load =SaveData.Instance;
        flagScore =Loader();
        Load.Reload();
     
    }
	
	// Update is called once per frame
	public int Loader () {
        var MyFlag;
        return flagScore;
	}

  
}
