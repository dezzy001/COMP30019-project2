using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;



/*

This class is to be drag and dropped on: Tutorial Panel 4

*/
public class tutorialPauseScript : MonoBehaviour {


	public Text pressEscText;

	public Button clickContinueButton;

	public GameObject nextTutorialPanel;

	private bool pressedEsc = false;
	private bool clickedContinue = false;

	public float DELAY_B4_NEXT_TUT = 0.4f;



	// Use this for initialization
	void Start () {
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

			StartCoroutine (delayBeforeNextTutorial());




		}

	}

	private void ifClickedContinue(){
		clickedContinue = true;

	}


	IEnumerator delayBeforeNextTutorial(){
		
		yield return new WaitForSeconds (DELAY_B4_NEXT_TUT);
		nextTutorialPanel.SetActive (true);
		this.gameObject.SetActive (false);

	}



}
