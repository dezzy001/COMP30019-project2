using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//need to include the UI components
using UnityEngine.UI;



public class StartUI : MonoBehaviour {

	/*Important things to clarify
	1)Anchor everything in UI - so all objects are responsive to resolution changes
	2)bottom to top ordering in UI: bottom game objects will overylay game objects above it (same hierarchy)*/

	//Panels
	public GameObject startPanel;
	public GameObject mainMenuPanel;
	public GameObject deleteSavePanel;

	//array of all panels
	public ArrayList allStartUIPanels;

	public AudioSource audioSource;
	public AudioClip[] audioClip;

	public Button deleteSavesButton;
	public SaveLoadManager saveLoadManager;



	// Use this for initialization
	void Start () {
		allStartUIPanels = new ArrayList ();

		allStartUIPanels.Add (startPanel);
		allStartUIPanels.Add (mainMenuPanel);
		allStartUIPanels.Add (deleteSavePanel);


		audioSource = GetComponent<AudioSource> ();

		//set all panels to false, other than the start Panel to true
		closeAllPanels();

		startPanel.SetActive (true);


	}



	public void clickToMainMenu(){

		audioSource.PlayOneShot (audioClip [0], 0.8f);

		startPanel.SetActive (false);
		mainMenuPanel.SetActive (true);
	}

	public void openAndClosePopUp(GameObject panel){
		if (panel.activeSelf == true) {
			audioSource.PlayOneShot (audioClip [1], 1.0f);
			panel.SetActive (false);
		} else {
			audioSource.PlayOneShot (audioClip [1], 1.0f);
			panel.SetActive (true);
		}

	}

	public void clickPlaySound(){

		audioSource.PlayOneShot (audioClip [1], 1.0f);

	}

	public void closeAllPanels(){
		SwitchToPanel.closeAllPanels (allStartUIPanels);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
