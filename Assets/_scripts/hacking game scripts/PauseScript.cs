using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour {

	public GameObject pausePanel;
	private ArrayList allHackingGamePanels = new ArrayList();

	public SwitchToPanel switchToPanelScript;

	private bool leavingGame = false;

	void Start(){
		//add all the panels in the scene here
		allHackingGamePanels.Add (pausePanel);
		pausePanel.SetActive (false);//dont want pause panel to show

	}


	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.Escape )  && !leavingGame) { //&& !leavingGame

			if(Time.timeScale == 1){
				
				Time.timeScale = 0;

				clickToPanel (pausePanel);

				//turn mouse on
				Cursor.visible = true;


			}else{
				
				pausePanel.SetActive (false);

				Time.timeScale = 1;

				//turn mouse off
				Cursor.visible = false;



			}

		}


	}


	public void clickToPanel(GameObject panel){
		switchToPanelScript.activatePanel (panel,this.allHackingGamePanels);
	}

	/*this is used when player exists the game, want to close all panels, and not allow player to "pause" during the load*/
	public void closeAllPanels(){
		switchToPanelScript.closeAllPanels (this.allHackingGamePanels);

		Time.timeScale = 1;
		leavingGame = true;
	}


}
