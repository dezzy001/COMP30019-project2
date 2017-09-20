using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;



/*

This class is to be drag and dropped on: Tutorial Panel 4

*/
public class tutorialPauseScript : TutorialSwitchPanelScript {


	public Text pressEscText;

	public Button clickContinueButton;


	private bool pressedEsc = false;
	private bool clickedContinue = false;




	public float DELAY_B4_NEXT_TUT = 0.35f;
	public GameObject nextPanel;



	// Use this for initialization
	void Start () {
		
		//want to activate the pause function at this stage of the tutorial
		PauseScript pauseScript = GameObject.Find("SceneManagement Script").GetComponent<PauseScript>();
		pauseScript.allowPauseKey = true;


		clickContinueButton.onClick.AddListener (ifClickedContinue);
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.Escape) && !pressedEsc){
			pressEscText.text = "<Click the \"Conitnue\" button>";
			pressedEsc = true;
		}

		if( clickedContinue){
			clickedContinue = false;
			//print ("clicked continue button!");

			StartCoroutine (delayBeforeNextTutorial(nextPanel,  DELAY_B4_NEXT_TUT));




		}

	}


	//a button listener
	private void ifClickedContinue(){
		clickedContinue = true;

	}





}
