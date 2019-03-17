using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] Message message;


    public void YesButton()
    {
        StartCoroutine(message.EachPatternDiplay(Pattern.Good));
    }

    public void NoButton()
    {
        StartCoroutine(message.EachPatternDiplay(Pattern.Bad));
    }
    // Update is called once per frame
    void Update()
    {

    }
}
