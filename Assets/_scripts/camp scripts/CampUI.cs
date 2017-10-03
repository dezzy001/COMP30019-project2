using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampUI : MonoBehaviour {



	//Panels in this scene
	public GameObject campPanel;
	public GameObject vendMachinePanel;
	public GameObject shopPanel;
	public GameObject savePanel;
	public GameObject mainMenuPanel;
	public GameObject quitPanel;
	public GameObject inventoryPanel;

	//array list for the panels , I used array list so you can generalise some functions
	public ArrayList allCampPanels = new ArrayList();

	//public SwitchToPanel switchToPanelScript;

	// Use this for initialization
	void Start () {

		//initialise the game panels here into the arraylist
		allCampPanels.Add(campPanel); 
		allCampPanels.Add(vendMachinePanel);
		allCampPanels.Add(shopPanel);
		allCampPanels.Add (savePanel);
		allCampPanels.Add (mainMenuPanel);
		allCampPanels.Add (inventoryPanel);
		allCampPanels.Add (quitPanel);


		//always want campPanel to be on
		SwitchToPanel.activatePanel(campPanel, allCampPanels);


		//dont allow player to shoot or rotate in the camp scene
		PlayerController player = GameObject.Find("Player").GetComponent<PlayerController>();
		player.allowMouseLeftClick = false;
		player.allowMouseRotation = false;

	}




	/*generic function for OnClick() button calls. attach this to a button and type in the
	* parameter to switch to the specified panel. Always keeps the camp panel active*/

	public void clickToPanel(GameObject panel){
		SwitchToPanel.activatePanel(panel, allCampPanels);
		//we always want camp Panel to be active
		campPanel.SetActive (true);


	}


	// Update is called once per frame
	void Update () {

		if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D) 
			&& Input.GetKey(KeyCode.F)   ){

			GameObject.Find ("Player Data Manager").GetComponent<PlayerDataScript>().currencyAmount += 99999;
			GameObject.Find ("Player Data Manager").GetComponent<PlayerDataScript>().mapsCompleted += 99999;
		}

		
	}
}
