using UnityEngine;

[CreateAssetMenu(fileName = "SongData", menuName = "ScriptableObjects/SongData", order = 0)]
public class SongData : ScriptableObject
{
    public string _titleName;
    public string _artistName;
    public string _albumName;
    public string _danceMove;
    public Sprite _albumImage;
    public AudioClip _audioClip;
    public Animation _songAnimation;
    public GameObject _songCharacter;
}
