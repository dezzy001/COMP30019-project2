using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*All the item effects currently in game go in this class*/
public class ItemsEffect : MonoBehaviour {

	//my idea: items will return the name of the item, while performing some effects on the player


	/*Chips description*/

	//chip0 - increase movement speed (increase ram)
	public void chip1(){
		print ("Chip 1 active");

	}

	//chip1 - increase invincibility CD time when hit
	public void chip2(){
		print ("Chip 2 active");

	}

	/*Upgrade description*/

	//upgrade1 - get 2 players shooting at once (dual core CPU)
	public void skill1(){
		print ("Skill 1 active");

	}


}
