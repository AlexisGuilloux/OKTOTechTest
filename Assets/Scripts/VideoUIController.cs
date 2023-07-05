using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class VideoUIController : MonoBehaviour
{
    [SerializeField] private UIDocument _uiDocument;

    private SongData _songData;

    private readonly Color _likedColor = new (0.7f, 0.08f, 0.08f, 1f);
    private readonly Color _sharedColor = new (0.1f, 0.2f, 0.7f, 1f);
    private readonly Color _defaultWhiteColor = Color.white;

    #region Refs

    //Buttons
    private Button _likedButton;
    private Button _shareButton;
    private Button _profileButton;
    private Button _danceButton;

    private readonly string _likedButtonRef = "LikeButton";
    private readonly string _shareButtonRef = "ShareButton";
    private readonly string _profileButtonRef = "ProfileButton";
    private readonly string _danceButtonRef = "DanceItButton";
    
    //Texts
    private Label _playerNameText;
    private Label _danceMoveText;
    private Label _artistNameText;
    private Label _songNameText;

    private readonly string _playerNameRef = "PlayerNameText";
    private readonly string _danceMoveRef = "MoveNameText";
    private readonly string _artistNameRef = "ArtistName";
    private readonly string _songNameRef = "SongName";
    
    
    //Images
    private Image _profileImage;
    private Image _albumImage;

    private readonly string _profileImageRef = "";
    private readonly string _albumImageRef = "AlbumCover";

    #endregion

    public UIDocument UIDocument => _uiDocument;
    public bool DataInitialized { get; private set; }
    private bool enabled = false;

    private void OnEnable()
    {
        //UIDocument have a weird behaviour where you can't set things in Awake and Start
        //What a unfriendly tool that is
        QueryAllElements();

        if(_songData == null)return;
        
        _playerNameText.text = "Player 01";
        _danceMoveText.text = _songData._danceMove;
        _artistNameText.text = _songData._artistName;
        _songNameText.text = _songData._titleName;
        DataInitialized = true;
        enabled = true;
    }

    private void OnDisable()
    {
        _playerNameText.text = "";
        _danceMoveText.text = "";
        _artistNameText.text = "";
        _songNameText.text = "";
        DataInitialized = false;
        enabled = false;
    }

    private void OnDestroy()
    {
        _likedButton.clicked -= OnLikeButtonPressed;
        _shareButton.clicked -= OnShareButtonPressed;
    }

    public void Init(SongData songData)
    {
        _songData = songData;
        gameObject.SetActive(true);
        if (!enabled)
        {
            OnEnable();
        }
    }

    public void Flush()
    {
        gameObject.SetActive(false);
    }


    private void QueryAllElements()
    {
        VisualElement rootVE = _uiDocument.rootVisualElement;
        _likedButton = rootVE.Q<Button>(name: _likedButtonRef);
        _likedButton.clicked += OnLikeButtonPressed;
        
        _shareButton = rootVE.Q<Button>(name: _shareButtonRef);
        _shareButton.clicked += OnShareButtonPressed;
        
        _profileButton = rootVE.Q<Button>(name: _profileButtonRef);
        _danceButton = rootVE.Q<Button>(name: _danceButtonRef);

        _playerNameText = rootVE.Q<Label>(name: _playerNameRef);
        _danceMoveText = rootVE.Q<Label>(name: _danceMoveRef);
        _artistNameText = rootVE.Q<Label>(name: _artistNameRef);
        _songNameText = rootVE.Q<Label>(name: _songNameRef);
    }
    
    private void OnLikeButtonPressed()
    {
        _likedButton.style.unityBackgroundImageTintColor = new StyleColor(_likedButton.style.unityBackgroundImageTintColor == _likedColor ? _defaultWhiteColor : _likedColor);
    }
    
    private void OnShareButtonPressed()
    {
        _likedButton.style.unityBackgroundImageTintColor = new StyleColor(_likedButton.style.unityBackgroundImageTintColor == _sharedColor ? _defaultWhiteColor : _sharedColor);
    }
}
