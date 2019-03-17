using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeImage : MonoBehaviour {
    Image image;
    Color color;
    [SerializeField]
    GalleryDateLoad galleryload;
    [SerializeField]
    Image Image1;
    [SerializeField]
    Image Image2;
    [SerializeField]
    Image Image3;
	// Use this for initialization
	void Start () {
        
        color = new Color(1,1,1,1);
      
	}
    private void Update()
    {
        if (galleryload.Trueend)
        {
            Image1.color = color;
        }
        if (galleryload.Normalend)
        {
            Image2.color = color;
        }
        if (galleryload.Badend)
        {
            Image3.color = color;
        }

    }

    // Update is called once per frame

}
