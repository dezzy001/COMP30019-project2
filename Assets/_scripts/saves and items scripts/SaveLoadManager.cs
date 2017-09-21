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

		//load player data every scene with Player object in it
		loadAll();

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


			playerDataScript.hasChip0 = loadedData.chips [0];
			playerDataScript.hasChip1 = loadedData.chips [1];
			playerDataScript.hasChip2 = loadedData.chips [2];
			playerDataScript.hasChip3 = loadedData.chips [3];

			playerDataScript.hasUpgrade0 = loadedData.upgrades [0];
			playerDataScript.hasUpgrade1 = loadedData.upgrades [1];
			playerDataScript.hasUpgrade2 = loadedData.upgrades [2];
			playerDataScript.hasUpgrade3 = loadedData.upgrades [3];



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




[Serializable] public class PlayerData {


	public bool[] chips;
	public bool[] upgrades;

	public int mapsCompleted;
	public int currencyAmount;

	//NOTE: whenever a constructor is changed all other constructors must also be changed

	//all the data we are saving from the script 

	//constructor 1 - all the data we want to save from an existing player data script
	public PlayerData(PlayerDataScript playerDataScript) {

		mapsCompleted = playerDataScript.mapsCompleted;

		currencyAmount = playerDataScript.currencyAmount;

		chips = new bool[4];
		chips [0] = playerDataScript.hasChip0; 
		chips [1] = playerDataScript.hasChip1;
		chips [2] = playerDataScript.hasChip2;
		chips [3] = playerDataScript.hasChip3;

		upgrades = new bool[4];
		upgrades [0] = playerDataScript.hasUpgrade0; 
		upgrades [1] = playerDataScript.hasUpgrade1;
		upgrades [2] = playerDataScript.hasUpgrade2;
		upgrades [3] = playerDataScript.hasUpgrade3;

	}

	//contructor 2 - to initialise a new playerdata 
	public PlayerData() {

		mapsCompleted = 0;

		currencyAmount = 0;

		chips = new bool[4];
		chips [0] = false; 
		chips [1] = false;
		chips [2] = false;
		chips [3] = false;

		upgrades = new bool[4];
		upgrades [0] = false; 
		upgrades [1] = false;
		upgrades [2] = false;
		upgrades [3] = false;

	}




}