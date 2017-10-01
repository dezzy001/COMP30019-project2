using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

/*Generates all the maps*/

public class MapGeneratorScript : MonoBehaviour {



	//get the scene manager script to switch scenes
	public SceneManagement sceneManagement;

	//get the playerDataScript
	private PlayerDataScript playerDataScript;

	//get a button prefab
	public GameObject selectMapButton_prefab;
	//public GameObject mapContent_prefab;

	//get the panel to add buttons to
	public GameObject mapGridPanel;


	//add sound to all the initialised buttons
	public ClickSound clickSound;

	// Use this for initialization
	void Start () {

		playerDataScript = GameObject.Find ("Player Data Manager").GetComponent<PlayerDataScript> ();



		/*--------------Item Generation below---------------*/


		//Initialise all Maps here and add them to the vending machine:
		/*Maps*/

		int mapsCompleted = playerDataScript.mapsCompleted;

		/*show map 1*/
		if(mapsCompleted >= 0){
			createNewMap("Tutorial", 0, "_TutorialLevel");
		}

		/*show map 2*/
		if(mapsCompleted >= 1){

			createNewMap("Map 1",1 , "level1");
		}

		/*show map 3*/
		if(mapsCompleted >= 2){

			createNewMap("Map 2",2 , "level2");
		}




	}
		

	//General Button functions below!


	/*creates a new button with specified text to a specified panel, with a listener attached*/
	void createNewMap( string buttonText, int mapNumber, string sceneString){

		GameObject newButton = Instantiate(selectMapButton_prefab);
		//set the text of the button to a specified one
		newButton.GetComponentInChildren<Text> ().text = buttonText;

		//make the button slightly darker if you have completed the level before
		if(mapNumber < playerDataScript.mapsCompleted ){
			newButton.GetComponent<Image> ().color = new Color(0.8f,0.8f,0.8f,1);
		}



		//to prevent scaling, set the second arguement (world scaling argument) to false
		newButton.transform.SetParent(mapGridPanel.transform,false);

		//add a listener which opens the item information when created
		newButton.GetComponent<Button> ().onClick.AddListener(() => goToMap(sceneString));

	}



	/*Creates the item content gameobject, makes it a child of Item Information panel
	 * , and shows the item informations (information of the items stored using Item class)*/
	void goToMap(string sceneString){//int contentID
		clickSound.PlaySound ();
		sceneManagement.changeScene(sceneString);

	}




}
