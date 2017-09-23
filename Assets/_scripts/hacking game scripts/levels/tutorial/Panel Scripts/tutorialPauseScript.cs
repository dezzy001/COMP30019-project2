using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;



/*

This class is to be drag and dropped on: Tutorial Panel 4

*/
public class tutorialPauseScript : TutorialSwitchPanelScript {

	public PlayerController playerScript;

	public Text pressEscText;

	public Button clickContinueButton;


	private bool pressedEsc = false;
	private bool clickedContinue = false;

	//activate tutorial arrows
	public GameObject arrow1; 
	public GameObject arrow2; 

	public PauseScript pauseScript;

	public float DELAY_B4_NEXT_TUT = 0.35f;
	public GameObject nextPanel;



	// Use this for initialization
	void Start () {
		
		//want to activate the pause function at this stage of the tutorial
		pauseScript = GameObject.Find("SceneManagement Script").GetComponent<PauseScript>();
		pauseScript.allowPauseKey = true;

		playerScript = GameObject.Find("Player").GetComponent<PlayerController>();

		clickContinueButton.onClick.AddListener (ifClickedContinue);
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.Escape) && !pressedEsc){
			pressEscText.text = "<Click the \"Continue\" button>";
			pressedEsc = true;

			//want time scale to still be one so the arrows can move
			playerScript.allowMouseRotation = false;
			playerScript.allowMouseLeftClick = false;
			Time.timeScale = 1;
			arrow1.SetActive (true);
			arrow2.SetActive (true);
			pauseScript.allowPauseKey = false;
		}

		if( clickedContinue){
			clickedContinue = false;

			//want time scale to still be one so the arrows can move
			playerScript.allowMouseRotation = true;
			playerScript.allowMouseLeftClick = true;
			pauseScript.allowPauseKey = true;


			arrow1.SetActive (false);
			arrow2.SetActive (false);
			//print ("clicked continue button!");

			StartCoroutine (delayBeforeNextTutorial(nextPanel,  DELAY_B4_NEXT_TUT));




		}

	}


	//a button listener
	private void ifClickedContinue(){
		clickedContinue = true;

	}





}
