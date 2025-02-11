using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using Vuforia;

public class VideoManager : MonoBehaviour
{
    // pos 0 , 4.84 ,0
    //Rot 90 , 0 , -180
    public VideoPlayer videoPlayer;
    public Button playVideoButton;

    public ObserverBehaviour observerBehaviour;

    private bool isButtonClicked;
    // Start is called before the first frame update
    void Start()
    {
        isButtonClicked = false;
        // Ensure the video doesn't start playing automatically
        videoPlayer.Stop();

        // Assign button click event
        playVideoButton.onClick.AddListener(PlayVideo);
        playVideoButton.gameObject.SetActive(false);

        if (observerBehaviour)
        {
            // Subscribe to the TargetStatusChanged event
            observerBehaviour.OnTargetStatusChanged += OnTargetStatusChanged;
        }
        else
        {
            Debug.LogError("ObserverBehaviour not found on this GameObject!");
        }
    }
    private void OnDestroy()
    {
        playVideoButton.onClick.RemoveAllListeners();
        if (observerBehaviour)
        {
            // Unsubscribe from the event to avoid memory leaks
            observerBehaviour.OnTargetStatusChanged -= OnTargetStatusChanged;
        }
    }

    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus targetStatus)
    {
        // Check if the target is found or lost
        if (targetStatus.Status == Status.TRACKED || targetStatus.Status == Status.TRACKED)
        {
            OnTargetFound();
        }
        else if (targetStatus.Status == Status.NO_POSE || targetStatus.Status == Status.LIMITED)
        {
            OnTargetLost();
        }
    }

    private void OnTargetFound()
    {
        playVideoButton.gameObject.SetActive(true);
        if (isButtonClicked==true)
        {
            videoPlayer.Play();
        }
    }

    private void OnTargetLost()
    {
        //playVideoButton.gameObject.SetActive(false);
        if (isButtonClicked == true)
        {
            videoPlayer.Pause();
        }
    }
    private void PlayVideo()
    {
        isButtonClicked = true;
        playVideoButton.gameObject.SetActive(false);
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause(); // Pause if playing
        }
        else
        {
            videoPlayer.Play(); // Play video
        }

    }
}
