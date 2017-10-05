using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*All the item effects currently in game go in this class*/
public class ItemData : MonoBehaviour {

	public GameObject playerGameObject;
	public PlayerController player;
	public PlayerDataScript playerDataScript;


	/*Items Here*/
	public Item chip1;
	public Item chip2;
	public Item chip3;
	public Item chip4;

	public Item skill1;
	public Item skill2;

	public Item skin1;

	//skin materials
	public Material originalMaterial;
	public Material originalCircleMaterial;

	public Material skin1Material;
	public Material skin1CircleMaterial;

	//Initial Player stats to increment
	public float initialPlayerInvincibilityCooldown = -1;

	void Start() {

		try{
			playerDataScript = GameObject.Find("Player Data Manager").GetComponent<PlayerDataScript>();
		}catch(Exception e){
			print ("ERROR - could not find Player Data Manager");
		}


		//Item (name, info, cost, capacity);
		//Initialise all items here and add the item to the shop:
		/*chips*/
		chip1 = new Item("Chip 1 - Invincibility","+0.5 sec extra invincibility cooldown when damaged",1000,1 );
		chip2 = new Item("Chip 2 - Player +1","+1 additional Player which does 25% of the players damage",5000,2 );
		chip3 = new Item("Chip 3 - Player +2","+2 additional Players which does 25% of the players damage",10000,3 );
		chip4 = new Item("Chip 4 - Player +7","You are basically a god, +7 additional Players which does 25% of the players damage",99999,5 );

		/*skills*/
		skill1 = new Item("Skill 1 - Laser","Shoots a laser beam, lots of damage",1000,4 );
		skill2 = new Item("Skill 2 - Saber","Throws a light saber from a galaxy far far away...",1000,4);

		/*skins*/
		skin1 = new Item("Skin 1 - Shadow Skin","You will be corrupted...",9999,0);





	}

	void Update() {

		try {
			player = GameObject.Find ("Player").GetComponent<PlayerController>();
			playerGameObject = GameObject.Find ("Player");
		} catch(Exception e) {
			//print ("No player object, please proceed to a scene with player object to load.");
			// saveLoadManager.newSaveAndLoadIt ();
		}

		//initialise player stats
		if(player != null && initialPlayerInvincibilityCooldown == -1){
			initialPlayerInvincibilityCooldown = player.INVINCIBILITY_COOLDOWN;
		}


	}


	/*Chips effects*/
	//chip0 - increase movement speed (increase ram)
	public void chip1Effect(bool active){


		//print ("Chip 1 active");
		if (player != null) {

			float bonus = 0.5f;

			if(active == true && initialPlayerInvincibilityCooldown == player.INVINCIBILITY_COOLDOWN){
				player.INVINCIBILITY_COOLDOWN += bonus;


			}else if(active == false &&  player.INVINCIBILITY_COOLDOWN ==  initialPlayerInvincibilityCooldown + bonus){
				player.INVINCIBILITY_COOLDOWN -= bonus;
			}
		}

	}

	//chip1 - increase invincibility CD time when hit
	public void chip2Effect(bool active){
		//print ("Chip 2 active");
		if (player != null) {
			if(active == true){
				player.allowOnePlayer = true;

			}else{
				player.allowOnePlayer = false;

			}

		}

	}

	public void chip3Effect(bool active){
		//print ("Chip 2 active");
		if (player != null) {
			if(active == true){
				player.allowTwoPlayer = true;

			}else{

				player.allowTwoPlayer = false;
			}

		}

	}

	public void chip4Effect(bool active){
		//print ("Chip 2 active");
		if (player != null) {
			if(active == true){
				player.allowSevenPlayer = true;

			}else{

				player.allowSevenPlayer = false;
			}

		}

	}

	public void chip5Effect(bool active){
		//print ("Chip 2 active");
		if (player != null) {
			if(active == true){


			}else{


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



	/*------------- Skins description ----------------*/

	//skin1 - GOLDEN SKIN
	public void skin1Effect(bool active){

		//print ("Skill 2 active");
		if (player != null) {
			if(active == true){
				applyMaterial (skin1Material,skin1CircleMaterial);
			}else{
				applyMaterial (originalMaterial,originalCircleMaterial);
			}
		} 
	}


	//skin methods



	void applyMaterial(Material skinMaterial, Material skinCircleMaterial){

		// grab the mesh renderer component from the object which is hit by player projectile
		MeshRenderer[] playerMesh = playerGameObject.GetComponentsInChildren<MeshRenderer> ();


		foreach (MeshRenderer playerBody in playerMesh) {


			if (playerBody.tag == "playerBody") {


				playerBody.sharedMaterial = skinMaterial;


			} else if(playerBody.tag == "playerCircle") {
				
				playerBody.sharedMaterial = skinCircleMaterial;
			}

		}

	}

}
