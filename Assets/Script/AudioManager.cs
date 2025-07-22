using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource musicSorce;
    [SerializeField] private AudioSource SFXSorce;

    [SerializeField] private AudioClip BgMusic;
    [SerializeField] private AudioClip FlipSFX;
    [SerializeField] private AudioClip WinSFX;
    [SerializeField] private AudioClip OverSFX;
    [SerializeField] private AudioClip MatchSFX;



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

    public void PlayFlipSFX()
    {
        PlaySFX(FlipSFX);
    }

    public void PlayOverSFX()
    {
        PlaySFX(OverSFX);
    }
    public void PlayWinSFX()
    {
        PlaySFX(WinSFX);
    }
    public void PlayMatchSFX()
    {
        PlaySFX(MatchSFX);
    }

    private void PlaySFX(AudioClip clip)
    {
        SFXSorce.PlayOneShot(clip);
    }
  
}
