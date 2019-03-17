using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeImage : MonoBehaviour {
    Image image;
    Color color;
	// Use this for initialization
	void Start () {
        image=GetComponent<Image>();
        color = new Color(1,1,1,1);
	}

    // Update is called once per frame
    public void changeColor()
    {
        image.color = color;
    }
}
