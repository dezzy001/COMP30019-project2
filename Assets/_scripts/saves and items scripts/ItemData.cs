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
	public Item skin2;
	public Item skin3;
	public Item skin4;
	public Item skin5;

	//skin materials
	public Material originalMaterial;
	public Material originalCircleMaterial;

	public Material skin1Material;
	public Material skin1CircleMaterial;
	public Material skin2Material;
	public Material skin2CircleMaterial;
	public Material skin3Material;
	public Material skin3CircleMaterial;
	public Material skin4Material;
	public Material skin4CircleMaterial;
	public Material skin5Material;
	public Material skin5CircleMaterial;

	//Initial Player stats to increment
	public float initialPlayerInvincibilityCooldown = -1;

	void Start() {

		try{
			playerDataScript = GameObject.Find("Player Data Manager").GetComponent<PlayerDataScript>();
		}catch(Exception e){
			print ("ERROR - could not find Player Data Manager");
		}


		//Item (name, info, cost, capacity,   buttonName, itemIndex);
		//Initialise all items here and add the item to the shop:
		/*chips*/
		chip1 = new Item("Chip 1 - Invulnerablilty Cooldown","+0.5 sec extra invincibility cooldown when damaged",1000,1    
			, "Cooldown", 0);
		chip2 = new Item("Chip 2 - Player +1","+1 additional Player which does 25% of the players damage",3500,2   
			,"Player +1", 1 );
		chip3 = new Item("Chip 3 - extra Player +1","+1 additional Player which does 25% of the players damage",4500,2 	
			,"Player +1",2);
		chip4 = new Item("Chip 4 - Player +7","You are basically a god, +7 additional Players which does 25% of the players damage",99999,5 	
			,"Player +7",3);

		/*skills*/
		skill1 = new Item("Skill 1 - Laser beam","Shoots a laser beam, lots of damage",3500,4
		,"Laser beam",0);
		skill2 = new Item("Skill 2 - Saber launcher","Throws a light saber from a galaxy far far away...",2000,4
		,"Saber launcher",1);

		/*skins*/
		skin1 = new Item("Skin 1 - Shadow Skin","You will be corrupted...",999,0
			,"Shadow",0);
		skin2 = new Item("Skin 2 - Toxic waste Skin","Time to detox?",999,0
			,"Toxic waste",1);
		skin3 = new Item("Skin 3 - Japan pack Skin","Japan!",499,0
			,"Japan pack",2);
		skin4 = new Item("Skin 4 - Camo Skin","You will be camoflauged...",1,0
			,"Camo",3);
		skin5 = new Item("Skin 5 - Player's Ghost","You will vindicate them...",666,0
			,"Player's Ghost",4);




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

	//skin1 
	public void skin1Effect(bool active){

		//print ("Skill 2 active");
		if (player != null) {
			if(active == true){
				applyMaterial (skin1Material,skin1CircleMaterial);
			}else{
				//applyMaterial (originalMaterial,originalCircleMaterial);
			}
		} 
	}
	//skin2
	public void skin2Effect(bool active){

		//print ("Skill 2 active");
		if (player != null) {
			if(active == true){
				applyMaterial (skin2Material,skin2CircleMaterial);
			}else{
				//applyMaterial (originalMaterial,originalCircleMaterial);
			}
		} 
	}
	//skin3
	public void skin3Effect(bool active){

		//print ("Skill 2 active");
		if (player != null) {
			if(active == true){
				applyMaterial (skin3Material,skin3CircleMaterial);
			}else{
				//applyMaterial (originalMaterial,originalCircleMaterial);
			}
		} 
	}
	//skin4
	public void skin4Effect(bool active){

		//print ("Skill 2 active");
		if (player != null) {
			if(active == true){
				applyMaterial (skin4Material,skin4CircleMaterial);
			}else{
				//applyMaterial (originalMaterial,originalCircleMaterial);
			}
		} 
	}

	public void skin5Effect(bool active){

		//print ("Skill 2 active");
		if (player != null) {
			if(active == true){
				applyMaterial (skin5Material,skin5CircleMaterial);
			}else{
				//applyMaterial (originalMaterial,originalCircleMaterial);
			}
		} 
	}


	//skin methods
	//og skin
	public void skinOriginalEffect(){

		//print ("Skill 2 active");
		if (player != null) {
			
				applyMaterial (originalMaterial,originalCircleMaterial);
	
		} 
	}

	/*version one applies a one material to players body and one to circle (NOTE need to make one apply a diff mat to each body part) */
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
