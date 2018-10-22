﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionDialog : Interaction {
    DialogManager dialogManager;
    [SerializeField] DialogText dialogText;

    public override bool IsChangingSceneDialog
    {
        get
        {
            throw new System.NotImplementedException();
        }

        set
        {
            throw new System.NotImplementedException();
        }
    }

    public override void Interact()
    {
        dialogManager.StartDialog(dialogText);

    }
    // Use this for initialization
    void Start () {
        dialogManager = GameObject.FindGameObjectWithTag("DialogManager").GetComponent<DialogManager>();
	}
}
