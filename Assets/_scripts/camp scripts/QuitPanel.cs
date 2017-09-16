using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitPanel : MonoBehaviour {

	public GameObject quitPanel;

	private bool switchOn = false;

	// Use this for initialization
	void Start () {

		quitPanel.SetActive (false);	
	}

	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown("escape")){
			switchOn = !switchOn;
			quitPanel.SetActive (switchOn);

		}

	}
}
