using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSceneDialog : MonoBehaviour {
    private bool havePlay;
    DialogManager dialogManager;
    [SerializeField] DialogText dialogText;
    // Use this for initialization
    void Awake()
    {
        dialogManager = GameObject.FindGameObjectWithTag("DialogManager").GetComponent<DialogManager>();
        dialogManager.StartDialog(dialogText);

    }
}
