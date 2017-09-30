using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


//change back to static?

public class SaveLoadManager : MonoBehaviour {



	//get the player gameobject
	public PlayerDataScript playerDataScript;


	void Awake(){
		//initialise the player game object
		playerDataScript = GameObject.Find ("Player Data Manager").GetComponent<PlayerDataScript>();

		if (playerDataScript == null) {
			print ("ERROR- cannot find playerDataScript in saveloadmanager");
		} 

	}




	public void newSaveAndLoadIt(){
		newSave ();
		loadAll ();

	}

	//start a new game function
	public void newSave(){


		//PlayerDataScript data = new PlayerDataScript ();

		PlayerDataScript data = gameObject.AddComponent<PlayerDataScript> ();
	

		SavePlayer (data);

	}


	/*save and load all data, functions*/
	public void saveAll(){
		SavePlayer (playerDataScript);

	}



	public int loadAll(){
		
		//loading player data
		PlayerData loadedData = LoadPlayer ();

		//if file exists then initialise the save values
		if (loadedData != null) {
			
			playerDataScript.mapsCompleted = loadedData.mapsCompleted;

			playerDataScript.currencyAmount = loadedData.currencyAmount;


			for(int i = 0; i < playerDataScript.CHIP_NUM ;i++){
				playerDataScript.chipsList[i] = loadedData.chips[i];
			}

			for(int i = 0; i < playerDataScript.SKILL_NUM ;i++){
				playerDataScript.skillsList[i] = loadedData.skills[i];
			}

			for(int i = 0; i < playerDataScript.SKIN_NUM ;i++){
				playerDataScript.skinsList[i] = loadedData.skills[i];
			}

			/*
			playerDataScript.chip1 = loadedData.chips [0];
			playerDataScript.chip2 = loadedData.chips [1];
			playerDataScript.chip3 = loadedData.chips [2];
			playerDataScript.chip4 = loadedData.chips [3];

			playerDataScript.skill1 = loadedData.skills [0];
			playerDataScript.skill1 = loadedData.skills [1];
			playerDataScript.skill1 = loadedData.skills [2];
			playerDataScript.skill1 = loadedData.skills [3];
			*/

			return 1; // successful load
		} else {

			print ("File does not exist, or loaded improperly");
			return 0;
		}
			

	}



	public  void SavePlayer(PlayerDataScript player) {
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream stream = new FileStream (Application.dataPath + "/zSaves/player.sav", FileMode.Create);

		// pass in the data of the player so that the class below can handle and store the player attributes
		// into the stats array
		PlayerData data = new PlayerData (player);

		bf.Serialize (stream, data);
		stream.Close ();
	}

	public  PlayerData LoadPlayer() { //instead of int[], try return PlayerData type
		// make sure the file exists
		if (File.Exists (Application.dataPath + "/zSaves/player.sav")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream stream = new FileStream (Application.dataPath + "/zSaves/player.sav", FileMode.Open);

			PlayerData data = bf.Deserialize (stream) as PlayerData; // cast it as PlayerData

			stream.Close ();

			return data; // return the data as PlayerData object
		} else {


			//Debug.LogError ("File does not exist.");
			print("Files does not exist");
			// return new int[4];
			return null;

		}
	}
		


}




