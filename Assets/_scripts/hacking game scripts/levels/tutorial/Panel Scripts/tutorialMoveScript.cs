using System.Collections;
using System.Collections.Generic;
using UnityEngine;




/*

This class is to be drag and dropped on: Tutorial Panel 5

*/
public class tutorialMoveScript : TutorialSwitchPanelScript {


	public float DELAY_B4_NEXT_TUT = 1.8f;
	public GameObject nextPanel;

	public PlayerController playerScript;


	// Use this for initialization
	void Start () {

		playerScript = GameObject.Find ("Player").GetComponent<PlayerController>();

		//allow player movement inputs
		playerScript.allowKeypressMovement = true;
	}
	
	// Update is called once per frame
	void Update () {

		//if player moves around a little then go to next panel
		if(Input.GetAxis ("Horizontal") > 0.1f || Input.GetAxis ("Vertical") > 0.1f){
			StartCoroutine (delayBeforeNextTutorial(nextPanel,  DELAY_B4_NEXT_TUT));
		}
	}




}
