﻿using System.Collections;
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

	}




	public void newSaveAndLoadIt(){
		newSave ();
		loadAll ();

	}

	//start a new game function
	public void newSave(){


		PlayerDataScript data = new PlayerDataScript ();
		SavePlayer (data);

	}


	/*save and load all data, functions*/
	public void saveAll(){
		SavePlayer (playerDataScript);

	}



	public void loadAll(){
		
		//loading player data
		PlayerData loadedData = LoadPlayer ();

		//if file exists then initialise the save values
		if (loadedData != null) {
			
			playerDataScript.mapsCompleted = loadedData.mapsCompleted;

			playerDataScript.currencyAmount = loadedData.currencyAmount;


			playerDataScript.chip1 = loadedData.chips [0];
			playerDataScript.chip2 = loadedData.chips [1];
			playerDataScript.chip3 = loadedData.chips [2];
			playerDataScript.chip4 = loadedData.chips [3];

			playerDataScript.skill1 = loadedData.skills [0];
			playerDataScript.skill1 = loadedData.skills [1];
			playerDataScript.skill1 = loadedData.skills [2];
			playerDataScript.skill1 = loadedData.skills [3];



		} else {

			print ("File does not exist, or loaded improperly");
		}
			

	}


	public  void SavePlayer(PlayerDataScript player) {
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream stream = new FileStream (Application.persistentDataPath + "/player.sav", FileMode.Create);

		// pass in the data of the player so that the class below can handle and store the player attributes
		// into the stats array
		PlayerData data = new PlayerData (player);

		bf.Serialize (stream, data);
		stream.Close ();
	}

	public  PlayerData LoadPlayer() { //instead of int[], try return PlayerData type
		// make sure the file exists
		if (File.Exists (Application.persistentDataPath + "/player.sav")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream stream = new FileStream (Application.persistentDataPath + "/player.sav", FileMode.Open);

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




