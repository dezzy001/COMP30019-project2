using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour {

	//panels
	public GameObject tutorial1;
	public GameObject tutorial2;
	public GameObject tutorial3;

	public SwitchToPanel switchToPanelScript;

	private ArrayList allTutorialPanels = new ArrayList();

	// Use this for initialization
	void Start () {
		allTutorialPanels.Add (tutorial1);
		allTutorialPanels.Add (tutorial2);
		allTutorialPanels.Add (tutorial3);

		clickToPanel (tutorial1);

	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void clickToPanel(GameObject panel){
		switchToPanelScript.activatePanel (panel,this.allTutorialPanels);
	}

	/*this is used when player exists the game, want to close all panels, and not allow player to "pause" during the load*/
	public void closeAllPanels(){
		
		switchToPanelScript.closeAllPanels (this.allTutorialPanels);

	}

}
