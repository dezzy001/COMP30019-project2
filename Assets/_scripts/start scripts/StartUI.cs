using System;
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

	//continue button: make uninteractable if there is no existing player.sav file

	//public Button deleteSavesButton;
	public GameObject continueButton;

	// get the save load manager script : this is to load the currently saved data every time you open the game
	public SaveLoadManager saveLoadManager;

	public PlayerDataScript playerDataScript;


	//load the previous game save everytime you start the game
	void Awake(){

		playerDataScript = GameObject.Find ("Player Data Manager").GetComponent<PlayerDataScript> ();

		try {


			int fileExists = saveLoadManager.loadAll ();

			//if file doesnt exist, then grey out the continue button and dont make it interactable
			if(fileExists == 0 || playerDataScript.mapsCompleted == 0 ){
				print("files does not exist");
				continueButton.GetComponent<Button> ().interactable = false;
				continueButton.GetComponent<Button> ().image.color = new Color(0.6f,0.6f,0.6f,0.6f);
			}

		} catch(Exception e) {
			print ("Old save not compatible, please make new save from camp.");
			// saveLoadManager.newSaveAndLoadIt ();
		}

	}


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
