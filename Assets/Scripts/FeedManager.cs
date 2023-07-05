using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FeedManager : MonoBehaviour
{
    [SerializeField] private SongData[] _songsData;

    [SerializeField] private VideoUIController _videoUIPrefab;
    [SerializeField] private int _poolNumber = 1;
    private List<VideoUIController> _videoUIPool;

    // Start is called before the first frame update
    void Start()
    {
        //Events subscription
        SwipeEvents.OnSwipeDetected += OnSwipe;
        
        //Init video feed
        _videoUIPool = new();

        for (int i = 0; i < _poolNumber; i++)
        {
            var instance = Instantiate(_videoUIPrefab, this.transform);
            instance.gameObject.SetActive(false);
            _videoUIPool.Add(instance);
        }
        _videoUIPool.First(x => x.DataInitialized == false).Init(_songsData[0]);
    }

    private void OnDestroy()
    {
        //Events subscription
        SwipeEvents.OnSwipeDetected -= OnSwipe;
    }

    private void OnSwipe(float yDirection)
    {
        if (yDirection > 0)
        {
            Debug.Log("Swipe up");
        }
        else
        {
            Debug.Log("Swipe down");
        }
    }
}
