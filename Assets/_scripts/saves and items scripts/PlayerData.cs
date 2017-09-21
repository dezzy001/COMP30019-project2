using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PlayerData {


	public bool[] chips;
	public bool[] upgrades;

	//total limit on the amount of items it can equip
	public int itemCapacity;

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

	//contructor 2 - to initialise a new playerdata (for a new game)
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