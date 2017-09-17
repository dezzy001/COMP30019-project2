using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAnimation : MonoBehaviour {


	public ParticleSystem spawnParticleSystem;

	private Component[] bodyParts;

	void Awake () {

		bodyParts = GetComponentsInChildren<Transform>();

		foreach(Transform body in bodyParts){
			if (body.CompareTag ("Body")) {
				body.gameObject.SetActive (false);
			}
		}

	}

	// Use this for initialization
	void Start () {
		//this.gameObject.SetActive (false);
		spawnParticleSystem = GetComponentInChildren<ParticleSystem> ();

		print (spawnParticleSystem);

	}


	void OnParticleCollision(){
		print ("ok...");

		foreach(Transform body in bodyParts){
			if(body.CompareTag("Body")){
				body.gameObject.SetActive (true);
			}
		}

	}

}
