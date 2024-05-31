using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; 
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
    public void Start()
    {
        PlayMusic("Music");
    }
    public void PlayMusic(string name)
    {
        var s = Array.Find(musicSounds, x => x.name == name); 
        musicSource.clip = s.clip;
        musicSource.Play();
    }
    public void PlaySFX(string name)
    {
        var s = Array.Find(sfxSounds, x => x.name == name);
        sfxSource.PlayOneShot(s.clip);
    }
    public void StopMusic()
    {
        musicSource.Stop();
    }
}