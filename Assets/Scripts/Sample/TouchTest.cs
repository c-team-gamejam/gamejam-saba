﻿using System.Collections;
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
            });
        }
    }
