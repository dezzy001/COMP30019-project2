using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*
 * This script contains all the data types which can be saved and loaded
 * also all the items effects are applied here
*/
using UnityEngine.SceneManagement;


public class PlayerDataScript : MonoBehaviour {


	//Total number of chips/skills/skins
	public int CHIP_NUM = 2;
	public int SKILL_NUM = 0;

	//get the items script to apply item effects if player has the item
	public ItemsEffect itemsEffect;

	public int[] chipsList;
	public int[] skillsList;


	/*variables below are used for saving and loading (have persistence)*/

	//the maps which player has completed
	public int mapsCompleted;

	//amount of in game money the player has
	public int currencyAmount;


	//check what items the player currently has and the how many quantity


	// Keep player data persistent
	void Awake () {

		if(SceneManager.GetActiveScene().name == "Start"){
			DontDestroyOnLoad (this.gameObject);
		}


		chipsList = new int[CHIP_NUM];
		skillsList = new int[SKILL_NUM];

		for(int i = 0; i < CHIP_NUM ;i++){
			chipsList[i] = 0 ;
		}

		for(int i = 0; i < SKILL_NUM ;i++){
			skillsList[i] = 0  ;
		}


	}

	// Use this for initialization
	void Start () {


		applyItems ();
		applySkills ();

	}
	
	// Update is called once per frame
	void Update () {

		//applyItems ();
		//applySkills ();
	}


	//apply the Chips to the player
	public void applyItems(){

		if(chipsList[0] > 0){

			for(int i = 0; i<chipsList[0] ; i++){
				itemsEffect.chip1 ();
			}


		}

		if(chipsList[1] > 0){
			for(int i = 0; i<chipsList[1] ; i++){
				itemsEffect.chip2 ();
			}

		}


		

	}

	public void applySkills(){
		


	}



}
