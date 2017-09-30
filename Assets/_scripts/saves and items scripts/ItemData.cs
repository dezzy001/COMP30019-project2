using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*All the item effects currently in game go in this class*/
public class ItemData : MonoBehaviour {

	public PlayerController player;
	public PlayerDataScript playerDataScript;


	/*Items Here*/
	public Item chip1;
	public Item chip2;

	public Item skill1;
	public Item skill2;

	public Item skin1;

	void Start() {

		try{
			playerDataScript = GameObject.Find("Player Data Manager").GetComponent<PlayerDataScript>();
		}catch(Exception e){
			print ("ERROR - could not find Player Data Manager");
		}

		//Initialise all items here and add the item to the shop:
		/*chips*/
		chip1 = new Item("Chip - Invincibility","+1 invincibility",100,2 );
		chip2 = new Item("Chip - +1 Player","+1 Player",1000,10 );

		/*skills*/
		skill1 = new Item("Skill 1 - Laser","Shoots a laser beam, lots of damage",100000,0 );
		skill2 = new Item("Skill 2 - Saber","Throws a light saber from a galaxy far far away...",100000,0);

		/*skins*/
		skin1 = new Item("Skin 1 - Golden Skin","YOU ARE RICH!",1000000,0);

	}

	void Update() {

		try {
			player = GameObject.Find ("Player").GetComponent<PlayerController>();
		} catch(Exception e) {
			//print ("No player object, please proceed to a scene with player object to load.");
			// saveLoadManager.newSaveAndLoadIt ();
		}


	}


	/*Chips effects*/

	//chip0 - increase movement speed (increase ram)
	public void chip1Effect(bool active){
		
		//print ("Chip 1 active");
		if (player != null) {
			
			if(active == true){
				print ("Chip 1 active");
			}else{
				//print ("Chip 1 NOT active");
			}
		}

	}

	//chip1 - increase invincibility CD time when hit
	public void chip2Effect(bool active){
		//print ("Chip 2 active");
		if (player != null) {
			if(active == true){
				print ("Chip 2 active");
			}else{
				//print ("Chip 2 NOT active");
			}

		}

	}

	//chip2 - get 2 players shooting at once (dual core CPU)

	/*------------- skill description ----------------*/


	//skill1 - laser
	public void skill1Effect(bool active){
		
		//print ("Skill 1 active");
		if (player != null) {
			if(active == true){
				player.allowLaser = true;
			}else{
				player.allowLaser = false;
			}
		} 

	}

	//skill2 - melee
	public void skill2Effect(bool active){
		
		//print ("Skill 2 active");
		if (player != null) {
			if(active == true){
				player.allowMelee = true;
			}else{
				player.allowMelee = false;
			}
		} 
	}

	//skill3 - missiles

	//skill4 - sword swing




}
