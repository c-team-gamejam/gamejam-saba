using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TouchTest : MonoBehaviour 
{
    TouchGestureDetector touchGestureDetector;

  

    private void Awake()
    {
        touchGestureDetector = TouchGestureDetector.Instance;
    }

    private void Start()
    {
        touchGestureDetector.onGestureDetected.AddListener((gesture, touchInfo) =>
        {
            if (gesture == TouchGestureDetector.Gesture.TouchBegin)
            {

                GameObject hitResultGameObject;
                var HitResult = touchInfo.HitDetection(out hitResultGameObject);
                if (HitResult)
                {
                    Debug.Log(hitResultGameObject.name);
                }
            }

            switch (gesture)
            {
                case TouchGestureDetector.Gesture.TouchBegin:
                    break;
                case TouchGestureDetector.Gesture.TouchMove:
                    break;
                case TouchGestureDetector.Gesture.TouchStationary:
                    break;
                case TouchGestureDetector.Gesture.TouchEnd:
                    break;
                case TouchGestureDetector.Gesture.Click:
                    break;
                case TouchGestureDetector.Gesture.FlickTopToBottom:
                    break;
                case TouchGestureDetector.Gesture.FlickBottomToTop:
                    break;
                case TouchGestureDetector.Gesture.FlickLeftToRight:
                    break;
                case TouchGestureDetector.Gesture.FlickRightToLeft:
                    break;
                default:
                    break;
            }
        });

        var touch = Input.GetTouch(0);
        
    }
}
