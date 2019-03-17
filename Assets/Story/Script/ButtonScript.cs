using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] Message message;


    public void YesButton()
    {
        Debug.Log("Yes");
        StartCoroutine(message.EachPatternDiplay(Pattern.Good));
    }

    public void NoButton()
    {
        Debug.Log("NO");

        StartCoroutine(message.EachPatternDiplay(Pattern.Bad));
    }
    // Update is called once per frame
    void Update()
    {

    }
}
