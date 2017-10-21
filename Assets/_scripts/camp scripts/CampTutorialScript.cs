using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CampTutorialScript : MonoBehaviour {


	private PlayerDataScript playerDataScript;

	public Button shopButton;
	public Button inventoryButton;
	public Button inventoryButton2;//the inventory button in the shop panel

	public GameObject campTutorialPanel;
	public GameObject campShopTutorialPanel;
	public GameObject campInventoryTutorialPanel;

	public ArrayList allTutorialPanels = new ArrayList();

	// Use this for initialization
	void Start () {
		playerDataScript = GameObject.Find ("Player Data Manager").GetComponent<PlayerDataScript> ();

		allTutorialPanels.Add (campTutorialPanel);
		allTutorialPanels.Add (campShopTutorialPanel);
		allTutorialPanels.Add (campInventoryTutorialPanel);

		closeTutorialPanels ();

		if(playerDataScript.hasDoneCampTutorial == false){
			SwitchToPanel.activatePanel (campTutorialPanel,allTutorialPanels);
			playerDataScript.hasDoneCampTutorial = true;

		}

		//set on click listener for shop and inventory button to show tutorial
		shopButton.onClick.AddListener(()=>shopTutorial());
		inventoryButton.onClick.AddListener (()=>inventoryTutorial());
		inventoryButton2.onClick.AddListener (()=>inventoryTutorial());

	}


	public void shopTutorial(){

		if(playerDataScript.hasDoneCampShopTutorial == false){
			playerDataScript.hasDoneCampShopTutorial = true;
			SwitchToPanel.activatePanel (campShopTutorialPanel,allTutorialPanels);
		}

	}

	public void inventoryTutorial(){

		if(playerDataScript.hasDoneCampInventoryTutorial == false){
			playerDataScript.hasDoneCampInventoryTutorial = true;
			SwitchToPanel.activatePanel (campInventoryTutorialPanel,allTutorialPanels);

		}



	}




	// Update is called once per frame
	void Update () {
		
	}



	public void runTutorial(){
		//make tutorial information buttons not interactable
	}

	public void closeTutorialPanels(){
		SwitchToPanel.closeAllPanels (allTutorialPanels);
	}
}
