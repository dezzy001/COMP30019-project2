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

	// Use this for initialization
	void Start () {

		//initialise the game panels here into the arraylist
		allCampPanels.Add(campPanel); 
		allCampPanels.Add(vendMachinePanel);
		allCampPanels.Add(shopPanel);

		//always want campPanel to be on
		activatePanel(campPanel, allCampPanels);

	}




	/*generic function for OnClick() button calls. attach this to a button and type in the
	* parameter to switch to the specified panel*/

	public void clickToPanel(GameObject panel){
		activatePanel (panel,this.allCampPanels);
		//we always want camp Panel to be active
		campPanel.SetActive (true);
	}



	/*make a reusable function in other scripts which turns all other panels to false
	-these functions assume that you have an arraylist of all your panels*/

	/*activaes the current panel in scene will deactivating all the other panels, this is 
	 currently used specificly for clickToPanel()
	if you are using this function in another script (say we make another map) then use this function as a starter.
	public void clickToPanel(GameObject panel){
		activatePanel (panel,this.allCampPanels);
	}
	 */

	static void activatePanel(GameObject panel, ArrayList allPanels){
		bool foundAPanel = false;
		foreach(GameObject p in allPanels){
			
			if (p == panel) {
				p.SetActive (true);
				foundAPanel = true;
			} else {
				p.SetActive (false);
			}
		}
		if(!foundAPanel){
			Debug.Log("Did not find the specified panel, please check the parameter you entered...");
		}

	}





	// Update is called once per frame
	void Update () {


		
	}
}
