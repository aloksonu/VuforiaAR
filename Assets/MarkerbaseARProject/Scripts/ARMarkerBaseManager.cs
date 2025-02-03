using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Vuforia;

public class ARMarkerBaseManager : MonoBehaviour
{
    public AudioSource audioSource;
    public Button playAudioButton;

    public ObserverBehaviour observerBehaviour;

    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = AudioManager.instance;//singleton
    }
    void Start()
    {
        playAudioButton.gameObject.SetActive(false);
        playAudioButton.onClick.AddListener(PlayAudio);


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
        playAudioButton.onClick.RemoveAllListeners();
        if (observerBehaviour)
        {
            // Unsubscribe from the event to avoid memory leaks
            observerBehaviour.OnTargetStatusChanged -= OnTargetStatusChanged;
        }
    }

    private void PlayAudio()
    {
        playAudioButton.gameObject.SetActive(false);
        //audioSource.Play();
        audioManager.PlaySFX(AudioManager.instance.introClip);

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
        // Add your logic for when the target is found
        Debug.Log("Target Found!");
        playAudioButton.gameObject.SetActive(true);
        audioSource.UnPause();
    }

    private void OnTargetLost()
    {
        // Add your logic for when the target is lost
        Debug.Log("Target Lost!");
        audioSource.UnPause();
    }

}
