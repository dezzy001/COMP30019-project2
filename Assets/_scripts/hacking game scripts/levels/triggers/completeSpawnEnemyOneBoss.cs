using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class completeSpawnEnemyOneBoss : levelScript {

	public GameObject enemyBoss1;
	public UnityEvent triggerEvent;

	// Use this for initialization
	void Start () {

		setEnemiesToChild ();
		gameStarted = true;
	}


	void Update () {


		if(gameStarted == true){

			if(transform.childCount == 0){
				triggerEvent.Invoke ();
				Destroy (this);
			}

			if (transform.childCount == 1){
				oneBossLeft (enemyBoss1);
			}

		}
	}



}
