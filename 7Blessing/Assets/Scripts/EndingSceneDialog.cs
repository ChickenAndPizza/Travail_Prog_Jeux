using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingSceneDialog : MonoBehaviour {
    DialogManager dialogManager;
    [SerializeField] DialogText dialogText;
    [SerializeField] string nextSceneName;
    //[SerializeField] AudioClip endingSound;

    //private AudioSource audioSource;
    public void Interact()
    {
        //audioSource.Play();
        //endingSound.Pl
        dialogManager.StartDialog(dialogText);
    }

    // Use this for initialization
    void Awake () {
        dialogManager = GameObject.FindGameObjectWithTag("DialogManager").GetComponent<DialogManager>();
    }

    // Update is called once per frame
    void Update () {
		if(nextSceneName != null && dialogManager.IsLastDialog)
        {
            SceneManager.LoadScene(nextSceneName);
        }
	}
}
