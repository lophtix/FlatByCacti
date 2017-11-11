using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {


    public AudioSource audio;
    public AudioClip music;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
        PlayClip(music);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayClip(AudioClip clip)
    {
        audio.clip = clip;

        audio.Play();
    }
}
