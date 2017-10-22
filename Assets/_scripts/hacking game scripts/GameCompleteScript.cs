using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class GameCompleteScript : MonoBehaviour {





	//save load manager to auto-save only after tutorial level is completed
	public SaveLoadManager saveLoadManager;

	public PlayerDataScript playerDatascript;
	public GameObject hackingCompletePanel;

	public SceneManagement sceneManagementScript;

	public int BASE_GOLD = 500;
	public Text goldText;

	//have all the map numbers CONST here
	//last map number
	private int MAP9 = 10;


	public int currentMapNum;
	string currSceneName;

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
		currentMapNum = MAP9;


	}


	// Update is called once per frame
	void Update () {


		if(hackingCompletePanel.activeSelf == true){


			if (playerDatascript.mapsCompleted < currentMapNum) {


				playerDatascript.mapsCompleted++;


				int goldReward = 300000;
				//only get gold once for each level
				playerDatascript.currencyAmount += goldReward;
				goldText.text = "+ "+goldReward+" Gold";




			} 






		}

	}



}
