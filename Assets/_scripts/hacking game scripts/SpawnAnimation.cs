using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAnimation : MonoBehaviour {


	public ParticleSystem spawnParticleSystem;

	//disable all these components until animation has collided with ground
	private Component[] bodyParts;
	private Component[] currentScripts;

	public string spawnAnimationFileNameWithoutSpaces = "SpawnAnimation";



	// Use this for initialization
	void Awake () {


		//this.gameObject.SetActive (false);
		spawnParticleSystem = GetComponentInChildren<ParticleSystem> ();

		bodyParts = GetComponentsInChildren<Transform>();

		//turn off all the body parts
		foreach(Transform body in bodyParts){
			if (body.CompareTag ("Body")) {
				body.gameObject.SetActive (false);
			}
		}

		//deactivae all the scrpits in the current object

		currentScripts = gameObject.GetComponents<MonoBehaviour>();
		foreach(MonoBehaviour script in currentScripts){

			if (script.GetType ().Name != spawnAnimationFileNameWithoutSpaces) {
				script.enabled = false;
			} 

		}
	}


	void OnParticleCollision(){

		/*VERY IMPORTANT - REMEMBER TO TURN OFF ISTRIGGER IN YOUR OBJECT - spent countless hours debugging this*/

		//activate all the body parts when animations occur
		foreach(Transform body in bodyParts){
			if( body.CompareTag("Body") ){
				body.gameObject.SetActive (true);
			}
		}


		//activae all the scrpits in the current object
		foreach(MonoBehaviour script in currentScripts){
			script.enabled = true;
		}

	}

}
