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
	public ArrayList upgradesList;


	/*variables below are used for saving and loading (have persistence)*/

	//the maps which player has completed
	public int mapsCompleted;

	//amount of in game money the player has
	public int currencyAmount;


	//check what items the player currently has

	/*chips*/
	public bool hasChip0;
	public bool hasChip1;
	public bool hasChip2;
	public bool hasChip3;

	/*upgrades*/
	public bool hasUpgrade0;
	public bool hasUpgrade1;
	public bool hasUpgrade2;
	public bool hasUpgrade3;



	// Keep player data persistent
	void Awake () {
		DontDestroyOnLoad (this.gameObject);
	}

	// Use this for initialization
	void Start () {
		//array list does not really work , unless u upgrade every load() you do
		//solution - need to create a applyLoad() function, so when you load, call this function too, to apply new changes to array lists
		chipsList = new ArrayList();
		upgradesList = new ArrayList();

		chipsList.Add (hasChip0);
		chipsList.Add (hasChip1);
		chipsList.Add (hasChip2);
		chipsList.Add (hasChip3);


		upgradesList.Add (hasUpgrade0);
		upgradesList.Add (hasUpgrade1);
		upgradesList.Add (hasUpgrade2);
		upgradesList.Add (hasUpgrade3);



		
		applyItems ();
		applyUpgrades ();

	}
	
	// Update is called once per frame
	void Update () {

	}


	//apply the Chips to the player
	public void applyItems(){
		
		if(this.hasChip0 == true){

			itemsEffect.chip0 ();
		}

		if(this.hasChip1 == true){

			itemsEffect.chip1 ();
		}

		if(this.hasChip2 == true){


		}

		if(this.hasChip3 == true){


		}
			

	}

	public void applyUpgrades(){
		
		if(this.hasUpgrade0 == true){
			itemsEffect.upgrade0 ();

		}

		if(this.hasUpgrade1 == true){


		}

		if(this.hasUpgrade2 == true){


		}

		if(this.hasUpgrade3 == true){


		}

	}



}
