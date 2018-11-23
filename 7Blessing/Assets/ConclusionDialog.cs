using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConclusionDialog : MonoBehaviour {
    DialogManager dialogManager;
    [SerializeField] DialogText dialogText;
    [SerializeField] string nextSceneName;
    [SerializeField] public GameObject menu;
    [SerializeField] public GameObject mainCanvas;
    // Use this for initialization
    void Awake()
    {
        dialogManager = GameObject.FindGameObjectWithTag("DialogManager").GetComponent<DialogManager>();
        dialogManager.StartDialog(dialogText);
    }

    public void ActivateMenu()
    {
        Instantiate(menu, mainCanvas.transform);
    }
}
