using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PlayerData {

	public int[] chips;
	public int[] skills;

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

		chips = new int[4];
		chips [0] = playerDataScript.chip1;
		chips [1] = playerDataScript.chip2;
		chips [2] = playerDataScript.chip3;
		chips [3] = playerDataScript.chip4;

		skills = new int[4];
		skills [0] = playerDataScript.skill1;
		skills [1] = playerDataScript.skill2;
		skills [2] = playerDataScript.skill3;
		skills [3] = playerDataScript.skill4;

	}

	//contructor 2 - to initialise a new playerdata (for a new game)
	public PlayerData() {

		mapsCompleted = 0;

		currencyAmount = 0;

		chips = new int[4];
		chips [0] = 0;
		chips [1] = 0;
		chips [2] = 0;
		chips [3] = 0;

		skills = new int[4];
		skills [0] = 0;
		skills [1] = 0;
		skills [2] = 0;
		skills [3] = 0;

	}




}