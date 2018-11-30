using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetNumberOfLives : MonoBehaviour {

    private Text textLives;
	// Use this for initialization
	void Start () {
        textLives = GetComponentInParent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        textLives.text = " X " + FindObjectOfType<PlayerStats>().lives.ToString();
	}
}
