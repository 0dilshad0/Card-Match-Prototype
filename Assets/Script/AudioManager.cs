using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource musicSorce;
    [SerializeField] private AudioSource SFXSorce;

    [SerializeField] private AudioClip BgMusic;
    public AudioClip FlipSFX;
    public AudioClip WinSFX;
    public AudioClip OverSFX;
    public AudioClip MatchSFX;



    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        musicSorce.clip = BgMusic;
        musicSorce.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSorce.PlayOneShot(clip);
    }
  
}
