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
	public int SKILL_NUM = 2;
	public int SKIN_NUM = 1;

	public int[] chipsList;
	public int[] skillsList;
	public int[] skinsList;

	//how many of the items the player owns has he equip
	public bool[] hasEquipchips ;
	public bool[] hasEquipskills ;
	public bool[] hasEquipSkins;

	/*variables below are used for saving and loading (have persistence)*/

	//the maps which player has completed
	public int mapsCompleted;

	//amount of in game money the player has
	public int currencyAmount;

	//total limit on the amount of items it can equip
	public int itemCapacity = 5;//have a default of 5 capacity

	//check what items the player currently has and the how many quantity

	//make sure there is only one instance of this class
	public static PlayerDataScript instance;


	//get all the item information from item generator script
	public ItemData itemData; // use this to know if item is equipped or not

	public Item chip1;
	public Item chip2;
	public Item skill1;
	public Item skill2;

	public Item skin1;

	public static bool createOnlyOnce = false;
	// Keep player data persistent
	void Awake () {



		if(SceneManager.GetActiveScene().name == "Start"){
			if(createOnlyOnce == false){
				DontDestroyOnLoad (this.gameObject);
				createOnlyOnce = true;
			}



		}


		itemData = GameObject.Find ("ItemData").GetComponent<ItemData> ();


		chipsList = new int[CHIP_NUM];
		skillsList = new int[SKILL_NUM];
		skinsList = new int[SKIN_NUM];

		hasEquipchips = new bool[CHIP_NUM];
		hasEquipskills = new bool[SKILL_NUM];
		hasEquipSkins = new bool[SKIN_NUM];

		for(int i = 0; i < CHIP_NUM ;i++){
			chipsList[i] = 0 ;
			hasEquipchips[i] = false ;
		}

		for(int i = 0; i < SKILL_NUM ;i++){
			skillsList[i] = 0  ;
			hasEquipskills[i] = false ;
		}

		for(int i = 0; i < SKIN_NUM ;i++){
			skinsList[i] = 0  ;
			hasEquipSkins[i] = false ;
		}


	}

	// Use this for initialization
	void Start () {

		//get all the item data from item generator script
		chip1 = itemData.chip1;
		chip2 = itemData.chip2;

		skill1 = itemData.skill1;
		skill2 = itemData.skill2;

		skin1 = itemData.skin1;
		//print (skin1);

		//print (chip1.itemName + ", "+chip1.itemCost+ ", "+ chip1.hasEquipItem);

		applyItems ();
		applySkills ();

	}
	
	// Update is called once per frame
	void Update () {
		applyItems ();
		applySkills ();
		//print (skillsList[0]);
	}


	//apply the Chips to the player
	public void applyItems(){




		//chip1

		//chip2





		//chip1
		if (chipsList [0] > 0 ) {
			
			itemData.chip1Effect(hasEquipchips[0]);

		} else {
			
			itemData.chip1Effect (false);
		}

		//chip2
		if (chipsList [1] > 0 ) {
			
			itemData.chip2Effect (hasEquipchips[1]);

		} else {
			itemData.chip1Effect (false);
		}



		

	}

	public void applySkills(){

		//skill1


		//skill2






		//skill1
		if(skillsList[0] > 0 ){
			itemData.skill1Effect(hasEquipskills[0]);
		}else {
			itemData.skill1Effect (false);
		}

		//skill2
		if(skillsList[1] > 0 ){
			
			itemData.skill2Effect(hasEquipskills[1]);

		}else {
			itemData.skill2Effect (false);

		}


	}



}
