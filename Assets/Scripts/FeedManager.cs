using System.Collections.Generic;
using UnityEngine;

public class FeedManager : MonoBehaviour
{
    [SerializeField] private SongData[] _songsData;
    [SerializeField] private SwipeManager _swipeManager;
    [SerializeField] private VideoController _videoPrefab;
    [SerializeField] private int _poolNumber = 3;
    private List<VideoController> _videoControllerPool;
    public List<VideoController> VideoControllerPool => _videoControllerPool;
    
    // Start is called before the first frame update
    void Start()
    {
        
        //Init video feed
        _videoControllerPool = new();

        for (int i = 0; i < _poolNumber; i++)
        {
            var instance = Instantiate(_videoPrefab, this.transform);
            instance.gameObject.SetActive(false);
            _videoControllerPool.Add(instance);
        }
        OnSwipe();
        
    }
    public void OnSwipe()
    {
        var songData = _songsData[_swipeManager.CurrentIndex];
        
        var characterInstance = Instantiate(songData._songCharacter, this.transform);
        characterInstance.transform.position = new Vector3(0f, 0f, -7f);
        characterInstance.transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
        characterInstance.GetComponent<Animator>().Play(0);
        
        _videoControllerPool[_swipeManager.CurrentIndex].Init(songData, characterInstance);
    }
}
