using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour {

	public GameObject pausePanel;
	private ArrayList allHackingGamePanels = new ArrayList();

	//public SwitchToPanel switchToPanelScript;

	//private bool leavingGame = false;

	//to get the blur script
	private Component[] cameraScripts;
	private MonoBehaviour blurScript;
	private string blurScriptFileName = "BlurOptimized";

	public bool allowPauseKey = true;

	void Start(){
		//add all the panels in the scene here
		allHackingGamePanels.Add (pausePanel);
		pausePanel.SetActive (false);//dont want pause panel to show

		cameraScripts = GameObject.Find ("Main Camera").GetComponents<MonoBehaviour>();


		foreach(MonoBehaviour blur in cameraScripts){

			if (blur.GetType ().Name == blurScriptFileName) {
				blurScript = blur;
				blurScript.enabled = false;
			} 

		}


	}


	// Update is called once per frame
	void Update () {

		if(allowPauseKey == true){
			if(Input.GetKeyDown(KeyCode.Escape)) { //&& !leavingGame

				//print ("escaping");

				if(Time.timeScale == 1){

					Time.timeScale = 0;

					clickToPanel (pausePanel);

					//turn mouse on
					Cursor.visible = true;


				}else{

					continueButton ();
					//turn mouse off
					Cursor.visible = false;



				}

			}

		}




	}


	public void clickToPanel(GameObject panel){

		blurScript.enabled = true;
		SwitchToPanel.activatePanel (panel,this.allHackingGamePanels);


	}

	/*this is used when player exists the game, want to close all panels, and not allow player to "pause" during the load*/
	public void closeAllPanels(){
		SwitchToPanel.closeAllPanels (this.allHackingGamePanels);

		Time.timeScale = 1;
		allowPauseKey = false;
	}

	public void continueButton(){
		SwitchToPanel.closeAllPanels (this.allHackingGamePanels);
		Time.timeScale = 1;

		blurScript.enabled = false;

	}


}
