using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LaserController : Projectile {

	public Vector3 velocity = new Vector3(0,0,0);
	//public int damageAmount = 200; // default player projectile damage

	void Start(){

		audioSource = GetComponent<AudioSource> ();

	}

	// Update is called once per frame
	void Update () {

		// this.transform.Translate(velocity * Time.deltaTime);

		timeToLive -= Time.deltaTime;

		if (timeToLive <= 0.0f) {
			Destroy (this.gameObject);
		}

	}




}
