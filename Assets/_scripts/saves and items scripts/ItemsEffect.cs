using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*All the item effects currently in game go in this class*/
public class ItemsEffect : MonoBehaviour {

	//my idea: items will return the name of the item, while performing some effects on the player

	public PlayerController player;

	void Start() {
//		if (player != null) {
//			player = GameObject.Find ("Player").GetComponent<PlayerController>();
//		}
	}

	void Update() {

		try {
			player = GameObject.Find ("Player").GetComponent<PlayerController>();
		} catch(Exception e) {
			print ("No player object, please proceed to a scene with player object to load.");
			// saveLoadManager.newSaveAndLoadIt ();
		}


	}

	/*Chips description*/

	//chip0 - increase movement speed (increase ram)
	public void chip1(){
		//print ("Chip 1 active");

	}

	//chip1 - increase invincibility CD time when hit
	public void chip2(){
		//print ("Chip 2 active");

	}

	//chip2 - get 2 players shooting at once (dual core CPU)

	/*------------- skill description ----------------*/

	//skill1 - laser
	public void skill1(){
		//print ("Skill 1 active");
		if (player != null) {
			player.allowLaser = true;
		}
	}

	//skill2 - melee
	public void skill2(){
		//print ("Skill 2 active");
		if (player != null) {
			player.allowMelee = true;
		}
	}

	//skill3 - missiles

	//skill4 - sword swing




}
