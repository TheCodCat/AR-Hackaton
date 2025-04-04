using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private GameObject playButton;
    [SerializeField] private bool isPlay;
    public void VideoPlayAndPause()
    {
        isPlay = !isPlay;
        if (isPlay)
            videoPlayer.Play();
        else
            videoPlayer.Pause();
        playButton.SetActive(false);
    }
}
