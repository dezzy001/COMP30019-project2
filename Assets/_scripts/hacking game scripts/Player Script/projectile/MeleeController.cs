using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MeleeController : Projectile {

	public Vector3 velocity = new Vector3(0,0,0);


	public int spinSpeed;



	void Start(){

		audioSource = GetComponent<AudioSource> ();



	}

	// Update is called once per frame
	void Update () {

		// this.transform.Translate(velocity * Time.deltaTime);
		this.transform.localRotation *= Quaternion.AngleAxis(spinSpeed * Time.deltaTime, Vector3.down);


		timeToLive -= Time.deltaTime;

		if (timeToLive <= 0.0f) {
			// this.gameObject.SetActive (false);

			Destroy (this.gameObject);
		}

	}





}
