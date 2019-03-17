using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] Message message;
    [SerializeField]
    AudioSource tapsound;

    public void YesButton()
    {
        tapsound.Play();
        Debug.Log("Yes");
        StartCoroutine(message.EachPatternDiplay(Pattern.Good));
    }

    public void NoButton()
    {
        tapsound.Play();
        Debug.Log("NO");
        StartCoroutine(message.EachPatternDiplay(Pattern.Bad));
    }
    // Update is called once per frame
    void Update()
    {

    }
}
