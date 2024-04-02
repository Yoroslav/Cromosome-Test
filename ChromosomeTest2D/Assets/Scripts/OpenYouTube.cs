using UnityEngine;

public class OpenYouTube : MonoBehaviour
{
    public string youtubeURL; 

    private void OnMouseDown()
    {
        Application.OpenURL(youtubeURL);
    }
}
