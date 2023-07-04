using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class VideoUIController : MonoBehaviour
{
    [SerializeField] private UIDocument _uiDocument;
    // Start is called before the first frame update
    void Start()
    {
        var danceItBtn = _uiDocument.rootVisualElement.Query<Button>(name: "DanceItButton").First();
        var songInfosGroup = _uiDocument.rootVisualElement.Query<VisualElement>(name: "SongInfos");
        var extraGroup = _uiDocument.rootVisualElement.Query<VisualElement>(name: "ExtraGroup");
        
        Debug.Log("done");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
