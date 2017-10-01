using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class HackingCompleteScript : MonoBehaviour {

	//save load manager to auto-save only after tutorial level is completed
	public SaveLoadManager saveLoadManager;

	public PlayerDataScript playerDatascript;
	public GameObject hackingCompletePanel;

	//have all the map numbers CONST here
	private int TUTORIAL = 1;
	private int MAP1 = 2;
	private int MAP2 = 3;
	private int MAP3 = 4;

	public int currentMapNum;

	// Use this for initialization
	void Awake () {

		try{
			playerDatascript = GameObject.Find ("Player Data Manager").GetComponent<PlayerDataScript> ();
			saveLoadManager = GameObject.Find ("Player Data Manager").GetComponentInChildren<SaveLoadManager> ();
	

		}
		catch(Exception e){
			print ("Cannot find player data script: Restart from \"Start\" Scene.");
		}

	}



	void Start(){
		hackingCompletePanel.SetActive (false);

		string currSceneName = SceneManager.GetActiveScene().name;

		if(currSceneName == "_TutorialLevel"){
			currentMapNum = TUTORIAL;
		}else if (currSceneName == "level1"){
			currentMapNum = MAP1;
		}else if (currSceneName == "level2"){
			currentMapNum = MAP2;
		}else if (currSceneName == "level3"){
			currentMapNum = MAP3;
		}


	}
	
	// Update is called once per frame
	void Update () {


		if(hackingCompletePanel.activeSelf == true){


			if (playerDatascript.mapsCompleted < currentMapNum) {


				playerDatascript.mapsCompleted++;
				//only get gold once for each level
				playerDatascript.currencyAmount += 500;

				//auto save for tutorial level only
				string currSceneName = SceneManager.GetActiveScene ().name;
				if (currSceneName == "_TutorialLevel") {
					saveLoadManager.saveAll ();
				}



			} 






		}

	}

}
