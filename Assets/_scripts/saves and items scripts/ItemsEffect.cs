using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*All the item effects currently in game go in this class*/
public class ItemsEffect : MonoBehaviour {

	//my idea: items will return the name of the item, while performing some effects on the player


	/*Chips description*/

	//chip0 - increase movement speed (increase ram)
	public string chip0(){
		print ("chip0 active");
		return "chip 0";

	}

	//chip1 - increase invincibility CD time when hit
	public string chip1(){
		print ("chip1 active");
		return "chip 1";
	}

	/*Upgrade description*/

	//upgrade1 - get 2 players shooting at once (dual core CPU)
	public string upgrade0(){
		print ("upgrade0 active");
		return "upgrade 0";

	}


}
