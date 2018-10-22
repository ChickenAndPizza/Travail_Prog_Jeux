using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingSceneDialog : Interaction {
    DialogManager dialogManager;
    [SerializeField] DialogText dialogText;
    [SerializeField] string nextSceneName;
    [SerializeField] AudioClip endingSound;
    [SerializeField] AudioClip nextSceneSound;

    private AudioSource audioSource;
    public override void Interact()
    {
        audioSource.PlayOneShot(endingSound);
        dialogManager.StartDialog(dialogText);
    }

    // Use this for initialization
    void Awake () {
        dialogManager = GameObject.FindGameObjectWithTag("DialogManager").GetComponent<DialogManager>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
		if(nextSceneName != null && dialogManager.IsLastDialog && dialogText.IsChangingSceneDialog)
        {
            GameObject music = GameObject.FindGameObjectWithTag("MusicPlayer");
            if (music != null)
            {
                MusicPlayer musicPlayer = music.GetComponent<MusicPlayer>();
                musicPlayer.ChangeMusic(nextSceneSound);
            }
            SceneManager.LoadScene(nextSceneName);
        }
	}
}
