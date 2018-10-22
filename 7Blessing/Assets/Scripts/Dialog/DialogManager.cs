using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour {
    [SerializeField] public GameObject dialogPrefab;
    [SerializeField] public GameObject mainCanvas;

    public bool IsLastDialog = false;

    private bool actionAxisInUser = true;
    private GameObject player;
    private bool dialogIsInitiated = false;
    private DialogText currentDialog;
    private DialogDisplayer currentDialogDisplayer;
	// Use this for initialization
	void Awake () {
        player = GameObject.FindGameObjectWithTag("Player");
        IsLastDialog = false;
    }

    // Update is called once per frame
    void Update () {
        ProcessInput();
	}

    public void StartDialog(DialogText newDialog)
    {
        dialogIsInitiated = true;
        player.GetComponent<Player_Move_Prot>().DisableControl();
        currentDialog = newDialog;
        GameObject currentDialogObject = Instantiate(dialogPrefab, mainCanvas.transform);
        currentDialogDisplayer = currentDialogObject.GetComponent<DialogDisplayer>();
        currentDialogDisplayer.SetDialogText(currentDialog.GetDialogText());
    }

    private void ProcessInput()
    {
        if (ShouldProcessInput())
        {
            actionAxisInUser = true;
            if (currentDialog.IsNextDialog())
            {
                currentDialog = currentDialog.GetNextDialog();
                currentDialogDisplayer.SetDialogText(currentDialog.GetDialogText());
            }
            else
            {
                EndDialog();
            }
        }
        ValidAxisInUser();  
    }

    private void EndDialog()
    {
        dialogIsInitiated = false;
        currentDialogDisplayer.CloseDialog();
        player.GetComponent<Player_Move_Prot>().EnableControl();
        IsLastDialog = true;
    }

    private bool ShouldProcessInput()
    {
        if(dialogIsInitiated)
        {
            if(!actionAxisInUser && Input.GetAxis("E") != 0)
            {
                return true;
            }
        }
        return false;
    }

    private void ValidAxisInUser()
    {
        if(Input.GetAxis("E") != 0)
        {
            actionAxisInUser = true;
        }
        else
        {
            actionAxisInUser = false;
        }
    }
}
