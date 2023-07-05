using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SwipeManager : MonoBehaviour
{
    private Vector2 _startPos;
    private VisualElement _targetElement;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _startPos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector2 endPos = Input.mousePosition;
            HandleSwipe(endPos);
        }
    }

    private void HandleSwipe(Vector2 endPos)
    {
        Vector2 swipeDirection = endPos - _startPos;

        if (!(swipeDirection.magnitude > 50)) return;
        
        SwipeEvents.OnSwipeDetected?.Invoke(swipeDirection.y);
    }
}