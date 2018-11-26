using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstSceneDialog : MonoBehaviour {
    DialogManager dialogManager;
    [SerializeField] DialogText dialogText;
    [SerializeField]public string nextSceneName;
    // Use this for initialization
    void Awake()
    {
        dialogManager = GameObject.FindGameObjectWithTag("DialogManager").GetComponent<DialogManager>();
        dialogManager.StartDialog(dialogText);
    }
}
