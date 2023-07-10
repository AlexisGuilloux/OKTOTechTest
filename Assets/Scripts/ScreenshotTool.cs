using System.Collections;
using UnityEngine;

public class ScreenshotTool : MonoBehaviour
{
    
    private static bool _takeScreenshotWithUI;
    private static Texture2D _screenshot;
    private WaitForEndOfFrame _frameEnd = new ();

    public void GetScreenshot(VideoController controller)
    {
        StartCoroutine(ProcessScreenshot());
    }
    
    private IEnumerator ProcessScreenshot()
    {
        yield return _frameEnd;
        _screenshot = new Texture2D(Screen.width, Screen.height, TextureFormat.ARGB32, false);
        
        _screenshot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        //_screenshot.LoadRawTextureData(_screenshot.GetRawTextureData());
        _screenshot.Apply();
        Events.OnScreenshotDone?.Invoke(_screenshot);
    }
}
