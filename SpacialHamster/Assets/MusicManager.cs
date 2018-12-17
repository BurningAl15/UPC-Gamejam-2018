using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {
    public static MusicManager instance;

    #region //Game sound Effects
    public AudioClip shootClip;
    public AudioClip hurtClip;
    public AudioClip deadClip;

    #endregion

    public AudioSource backgroundSource;
    public AudioSource soundEffects;

    private void Awake()
    {
        if (MusicManager.instance == null)
        {
            MusicManager.instance = this;
        }
        else if (MusicManager.instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void PlayHurt()
    {
        PlayAudio(hurtClip);
    }

    public void PlayShoot()
    {
        PlayAudio(shootClip);
    }

    public void PlayExplosion()
    {
        PlayAudio(deadClip);
    }

    void PlayAudio(AudioClip cs)
    {
        soundEffects.clip = cs;
        soundEffects.Play();
    }

    private void OnDestroy()
    {
        if (MusicManager.instance == this)
        {
            MusicManager.instance = null;
        }
    }
}
