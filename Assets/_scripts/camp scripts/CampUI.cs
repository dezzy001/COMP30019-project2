using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampUI : MonoBehaviour {



	//Panels in this scene
	public GameObject campPanel;
	public GameObject vendMachinePanel;
	public GameObject shopPanel;

	//array list for the panels , I used array list so you can generalise some functions
	public ArrayList allCampPanels = new ArrayList();

	//public SwitchToPanel switchToPanelScript;

	// Use this for initialization
	void Start () {

		//initialise the game panels here into the arraylist
		allCampPanels.Add(campPanel); 
		allCampPanels.Add(vendMachinePanel);
		allCampPanels.Add(shopPanel);

		//always want campPanel to be on
		SwitchToPanel.activatePanel(campPanel, allCampPanels);

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


		
	}
}
