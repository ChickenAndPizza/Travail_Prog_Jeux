using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    AudioSource audioSource;
	// Use this for initialization
	void Awake () {
        int countOfMusicPlayer = FindObjectsOfType<MusicPlayer>().Length;
        if(countOfMusicPlayer > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            audioSource = GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
        }
	}

    public void ChangeMusic(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}
