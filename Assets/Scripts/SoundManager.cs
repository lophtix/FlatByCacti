using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public AudioSource sfxSource;
    public AudioSource musicSource;
    public static SoundManager instance = null;

	// Use this for initialization
	void Start () {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlaySingle(AudioClip clip)
    {
        sfxSource.clip = clip;
        sfxSource.Play();
    }

    public void PlayMusic(AudioClip music)
    {
        musicSource.clip = music;
        musicSource.Play();
    }
}
