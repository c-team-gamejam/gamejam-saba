using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Scale : MonoBehaviour
{
    
    [SerializeField]
    GameObject image1;
    [SerializeField]
    GameObject image2;
    private bool flag = false;
   public void Scaler()
    {
        flag = !flag;
        if (flag)
        {
            iTween.ScaleAdd(gameObject, iTween.Hash("y", 1f, "time", 1f));
            image1.SetActive(false);
            image2.SetActive(false);
        }
        else if (!flag) {
            iTween.ScaleAdd(gameObject, iTween.Hash("y", -1f, "time", 1f));
            image1.SetActive(true);
            image2.SetActive(true);
        }
    }
}
