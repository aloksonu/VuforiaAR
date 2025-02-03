using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    //public AudioClip bgClip;
    public AudioClip introClip;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } 
    }
    // Start is called before the first frame update
    void Start()
    {
        //musicSource.clip = bgClip;
        musicSource.Play();

    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

}
