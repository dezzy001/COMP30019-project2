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

		/*show map tutorial*/
		if(mapsCompleted >= 0){
			createNewMap("Tutorial", 0, "_TutorialLevel");
		}

		/*show map 1*/
		if(mapsCompleted >= 1){

			createNewMap("Map 1",1 , "level1");
		}

		/*show map 2*/
		if(mapsCompleted >= 2){

			createNewMap("Map 2",2 , "level2");
		}

		/*show map 3*/
		if(mapsCompleted >= 3){

			createNewMap("Map 3",3 , "level3");
		}

		/*show map 4*/
		if (mapsCompleted >= 4) {

			createNewMap ("Map 4", 4, "level4");
		}

		/*show map 5*/
		if (mapsCompleted >= 5) {

			createNewMap ("Map 5", 5, "level5");
		}

		/*show map 6*/
		if (mapsCompleted >= 6) {

			createNewMap ("Map 6", 6, "level6");
		}

		/*show map 7*/
		if (mapsCompleted >= 7) {

			createNewMap ("Map 7", 7, "level7");
		}

		/*show map 8*/
		if (mapsCompleted >= 8) {

			createNewMap ("Map 8", 8, "level8");
		}

		/*show map 9*/
		if (mapsCompleted >= 9) {

			createNewMap ("Map 9", 9, "level9");
		}

		/*show map 10*/
		if (mapsCompleted >= 10) {

			createNewMap ("Map 10", 10, "level10");
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
