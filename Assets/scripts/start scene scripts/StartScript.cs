using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//need to include the UI components
using UnityEngine.UI;



public class StartScript : MonoBehaviour {

	/*Important things to clarify
	1)Anchor everything in UI - so all objects are responsive to resolution changes
	2)bottom to top ordering in UI: bottom game objects will overylay game objects above it (same hierarchy)*/


	public GameObject startPanel;
	public GameObject mainMenuPanel;

	// Use this for initialization
	void Start () {

		//set all panels to false, other than the start Panel to true
		//do not show
		mainMenuPanel.SetActive (false);
		//show
		startPanel.SetActive (true);
	}

	public void clickToMainMenu(){
		startPanel.SetActive (false);
		mainMenuPanel.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
