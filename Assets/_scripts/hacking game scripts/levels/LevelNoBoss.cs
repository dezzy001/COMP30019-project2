using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelNoBoss : levelScript {

	void Start () {

		setEnemiesToChild ();
		gameStarted = true;
	}


	void Update () {


		if(gameStarted == true){

			if(transform.childCount == 0){
				showHackingPanel();
			}

		}
	}
}
