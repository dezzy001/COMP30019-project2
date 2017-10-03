using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneBoss : levelScript {

	public GameObject enemyBoss1;

	// Use this for initialization
	void Start () {

		setEnemiesToChild ();
		gameStarted = true;
	}
	

	void Update () {


		if(gameStarted == true){
			
			if(transform.childCount == 0){
				showHackingPanel();
			}

			if (transform.childCount == 1){
				oneBossLeft (enemyBoss1);
			}

		}
	}



}
