using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class completeSpawnEnemyNoBoss : levelScript {


	public UnityEvent triggerEvent;

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

		}
	}



}
