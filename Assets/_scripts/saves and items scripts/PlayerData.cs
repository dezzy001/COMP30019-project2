using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PlayerData {

	/*
	public int[] chips;
	public int[] skills;
	*/

	//how many items the player owns
	public int[] chips ;
	public int[] skills ;

	//how many of the items the player owns has he equip
	//public bool[] hasEquipchips ;
	//public bool[] hasEquipskills ;


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

		chips = new int[playerDataScript.CHIP_NUM];
		skills = new int[playerDataScript.SKILL_NUM];

		for(int i = 0; i < playerDataScript.CHIP_NUM ; i++){
			chips[i] = playerDataScript.chipsList[i];

		}

		for(int i = 0; i < playerDataScript.SKILL_NUM ; i++){
			skills [i] = playerDataScript.skillsList [i];

		}



	}
		


}