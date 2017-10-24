using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToPanel : MonoBehaviour {



	/*make a reusable function in other scripts which turns all other panels to false
	-these functions assume that you have an arraylist of all your panels*/

	/*activaes the current panel in scene will deactivating all the other panels, this is 
	 currently used specificly for clickToPanel()
	if you are using this function in another script (say we make another map) then use this function as a starter.
	

	public void clickToPanel(GameObject panel){
		activatePanel (panel,this.allPanels);
	}


	 */

	public static void activatePanel(GameObject panel, ArrayList allPanels){
		
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
			//Debug.Log("Did not find the specified panel, please check the parameter you entered...");
		}

	}



	public static void closeAllPanels(ArrayList allPanels){

		foreach(GameObject p in allPanels){
			p.SetActive (false);
		}

	}

}
