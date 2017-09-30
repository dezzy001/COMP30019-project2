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
	public int SKIN_NUM = 0;

	public int[] chipsList;
	public int[] skillsList;
	public int[] skinsList;


	/*variables below are used for saving and loading (have persistence)*/

	//the maps which player has completed
	public int mapsCompleted;

	//amount of in game money the player has
	public int currencyAmount;


	//check what items the player currently has and the how many quantity

	//make sure there is only one instance of this class
	public static PlayerDataScript instance;


	//get all the item information from item generator script
	public ItemData itemData; // use this to know if item is equipped or not

	public Item chip1;
	public Item chip2;
	public Item skill1;
	public Item skill2;



	// Keep player data persistent
	void Awake () {



		if(SceneManager.GetActiveScene().name == "Start"){

			if(instance == null){
				DontDestroyOnLoad (this.gameObject);
			}else if (instance != null){
				Destroy (this.gameObject);
			}


		}


		itemData = GameObject.Find ("ItemData").GetComponent<ItemData> ();


		chipsList = new int[CHIP_NUM];
		skillsList = new int[SKILL_NUM];
		skinsList = new int[SKIN_NUM];

		for(int i = 0; i < CHIP_NUM ;i++){
			chipsList[i] = 0 ;
		}

		for(int i = 0; i < SKILL_NUM ;i++){
			skillsList[i] = 0  ;
		}

		for(int i = 0; i < SKIN_NUM ;i++){
			skillsList[i] = 0  ;
		}


	}

	// Use this for initialization
	void Start () {

		//get all the item data from item generator script
		chip1 = itemData.chip1;
		chip2 = itemData.chip2;

		skill1 = itemData.skill1;
		skill2 = itemData.skill2;

		//print (chip1.itemName + ", "+chip1.itemCost+ ", "+ chip1.hasEquipItem);

		applyItems ();
		applySkills ();

	}
	
	// Update is called once per frame
	void Update () {

		applyItems ();
		applySkills ();
	}


	//apply the Chips to the player
	public void applyItems(){

		//chip1
		itemData.chip1Effect(chip1.hasEquipItem);
		//chip2
		itemData.chip2Effect (chip2.hasEquipItem);



		/*
		//chip1
		if (chipsList [0] > 0 && chip1.hasEquipItem) {
			
			itemData.chip1Effect (true);

		} else {
			
			itemData.chip1Effect (false);
		}

		//chip2
		if (chipsList [1] > 0 && chip2.hasEquipItem) {
			itemData.chip2Effect (true);

		} else {
			itemData.chip1Effect (false);
		}
		*/


		

	}

	public void applySkills(){

		//skill1
		itemData.skill1Effect(skill1.hasEquipItem);

		//skill2
		itemData.skill2Effect(skill2.hasEquipItem);




		/*
		//skill1
		if(skillsList[0] > 0 && skill1.hasEquipItem){
			
			itemData.skill1Effect (true);
		}else {
			
			itemData.skill1Effect (false);
		}

		//skill2
		if(skillsList[1] > 0 && skill2.hasEquipItem){
			
			itemData.skill2Effect (true);

		}else {
			
			itemData.skill2Effect (false);
		}
		*/

	}



}
