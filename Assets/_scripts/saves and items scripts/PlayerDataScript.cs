using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*
 * This script contains all the data types which can be saved and loaded
 * also all the items effects are applied here
*/


public class PlayerDataScript : MonoBehaviour {


	//get the items script to apply item effects if player has the item
	public ItemsEffect itemsEffect;


	public ArrayList chipsList;
	public ArrayList skillsList;


	/*variables below are used for saving and loading (have persistence)*/

	//the maps which player has completed
	public int mapsCompleted;

	//amount of in game money the player has
	public int currencyAmount;


	//check what items the player currently has and the how many quantity

	/*chips*/
	public int chip1;
	public int chip2;
	public int chip3;
	public int chip4;

	/*skills*/
	public int skill1;
	public int skill2;
	public int skill3;
	public int skill4;



	// Keep player data persistent
	void Awake () {
		DontDestroyOnLoad (this.gameObject);
	}

	// Use this for initialization
	void Start () {
		//array list does not really work , unless u upgrade every load() you do
		//solution - need to create a applyLoad() function, so when you load, call this function too, to apply new changes to array lists
		chipsList = new ArrayList();
		skillsList = new ArrayList();



		applyItems ();
		applyUpgrades ();

	}
	
	// Update is called once per frame
	void Update () {

	}


	//apply the Chips to the player
	public void applyItems(){
		

		if(this.chip1 > 0){

		}

		if(this.chip2 > 0){

		}

		if(this.chip3 > 0){


		}

		if(this.chip4 > 0){


		}
			

	}

	public void applyUpgrades(){
		

		if(this.skill1 > 0){

		}

		if(this.skill2 > 0){


		}

		if(this.skill3 > 0){


		}

		if(this.skill4 > 0){


		}

	}



}
