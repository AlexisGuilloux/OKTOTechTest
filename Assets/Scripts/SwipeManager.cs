using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SwipeManager : MonoBehaviour
{
    [SerializeField] private FeedManager _feedManager;
    
    private Vector2 swipeStartPos;
    private VisualElement contentParent;
    private int currentIndex = 0;
    
    private VideoUIController ActiveVideo => _feedManager._videoUIPool.Find(x => x.DataInitialized);
    
    private void Start()
    {
        contentParent = ActiveVideo.UIDocument.rootVisualElement.Q("MainVideoUI");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseDown();
        }

        if (Input.GetMouseButton(0))
        {
            MousePressed();
        }

        if (Input.GetMouseButtonUp(0))
        {
            MouseUp();
        }
    }

    void MouseDown()
    {
        swipeStartPos = Input.mousePosition;
    }

    private void MousePressed()
    {
        if (currentIndex != _feedManager._videoUIPool.IndexOf(ActiveVideo)) return;
        
        Vector2 swipeEndPos = Input.mousePosition;
        Vector2 swipeDirection = swipeStartPos - swipeEndPos;
        contentParent.transform.position = new Vector3(contentParent.transform.position.x, swipeDirection.y, contentParent.transform.position.z);
    }
    
    void MouseUp()
    {
        Vector2 swipeEndPos = Input.mousePosition;
        Vector2 swipeDirection = swipeEndPos - swipeStartPos;

        if (Mathf.Abs(swipeDirection.y) > Mathf.Abs(swipeDirection.x))
        {
            if (swipeDirection.y > 0 && currentIndex > 0)
            {
                currentIndex--;
            }
            else if (swipeDirection.y < 0 && currentIndex < contentParent.childCount - 1)
            {
                currentIndex++;
            }
        }

        float targetPosition = -currentIndex * contentParent.layout.height;
        var endValue = new Vector3(contentParent.transform.position.x, targetPosition, contentParent.transform.position.z);
        Vector3 a = contentParent.transform.position;
        contentParent.transform.position = endValue;
    }
}