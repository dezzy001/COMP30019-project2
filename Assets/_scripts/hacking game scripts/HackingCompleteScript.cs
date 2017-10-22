using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class HackingCompleteScript : MonoBehaviour {

	//save load manager to auto-save only after tutorial level is completed
	public SaveLoadManager saveLoadManager;

	public PlayerDataScript playerDatascript;
	public GameObject hackingCompletePanel;
	public Button nextLevelButton;

	public SceneManagement sceneManagementScript;

	public int BASE_GOLD = 500;
	public Text goldText;

	//have all the map numbers CONST here
	private int TUTORIAL = 1;
	private int MAP1 = 2;
	private int MAP2 = 3;
	private int MAP3 = 4;
	private int MAP4 = 5;
	private int MAP5 = 6;
	private int MAP6 = 7;
	private int MAP7 = 8;
	private int MAP8 = 9;
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

		currSceneName = SceneManager.GetActiveScene().name;

		if (currSceneName == "_TutorialLevel") {
			currentMapNum = TUTORIAL;
		} else if (currSceneName == "level1") {
			currentMapNum = MAP1;
		} else if (currSceneName == "level2") {
			currentMapNum = MAP2;
		} else if (currSceneName == "level3") {
			currentMapNum = MAP3;
		} else if (currSceneName == "level4") {
			currentMapNum = MAP4;
		}else if (currSceneName == "level5") {
			currentMapNum = MAP5;
		}else if (currSceneName == "level6") {
			currentMapNum = MAP6;
		}else if (currSceneName == "level7") {
			currentMapNum = MAP7;
		}else if (currSceneName == "level8") {
			currentMapNum = MAP8;
		}else if (currSceneName == "level9") {
			currentMapNum = MAP9;
		}


		//create an on click listener for next level button
		nextLevelButton.onClick.AddListener(()=>nextLevel());

	}

	public void nextLevel(){

		Regex re = new Regex(@"([a-zA-Z]+)(\d+)");
		Match result = re.Match (currSceneName);



		string letterPart = result.Groups [1].Value;
		int numberPart = int.Parse(result.Groups [2].Value) ;



		numberPart++;

		string nextSceneName = letterPart + numberPart.ToString();


		sceneManagementScript.changeScene (nextSceneName);
	}
	
	// Update is called once per frame
	void Update () {


		if(hackingCompletePanel.activeSelf == true){


			if (playerDatascript.mapsCompleted < currentMapNum) {


				playerDatascript.mapsCompleted++;



				int goldReward = BASE_GOLD + (int)(BASE_GOLD*0.33f*currentMapNum*UnityEngine.Random.Range (50,100)/100);
				//only get gold once for each level
				playerDatascript.currencyAmount += goldReward;
				goldText.text = "+ "+goldReward+" Gold";


				//auto save for tutorial level only
				string currSceneName = SceneManager.GetActiveScene ().name;
				if (currSceneName == "_TutorialLevel") {
					saveLoadManager.saveAll ();
				}



			} 






		}

	}

}
