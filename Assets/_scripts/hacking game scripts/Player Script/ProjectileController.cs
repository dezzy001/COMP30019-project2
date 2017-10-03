﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProjectileController : MonoBehaviour {

	public Vector3 velocity = new Vector3(40,0,0);
	public int damageAmount = 25; // default player projectile damage

    public string tagToDamage = "Enemy";
	public string tagUntouchableEnemys = "EnemyUntouchable";

	public string tagWallWhite =  "Wallwhite";
	public string tagWallGrey = "Wallgrey";

	public AudioSource audioSource;
	public AudioClip[] audioClip;

	public float timeToLive;

	private int laserFireSound = 0;
	private int bulletHitSound = 1;
	private int bulletHitUntouchableSound = 2;

	//flash animation using glow material
	public Material flashMaterial;
	public float FLASH_WAIT = 0.1f;


	void Start(){

		audioSource = GetComponent<AudioSource> ();

		// Play the laser firing sound
		audioSource.PlayOneShot (audioClip [laserFireSound], 0.8f);

		// MeshRenderer renderer = this.GetComponent<MeshRenderer> ();
		// renderer.material.color = Color.yellow;


	}

    // Update is called once per frame
    void Update () {

        this.transform.Translate(velocity * Time.deltaTime);

		timeToLive -= Time.deltaTime;

		if (timeToLive <= 0.0f) {
			Destroy (this.gameObject);
		}

	}




	IEnumerator flashBlink(Material originalMaterial, MeshRenderer flashMaterial){

		yield return new WaitForSeconds (FLASH_WAIT);
		flashMaterial.material = originalMaterial;


	}




    // Handle collisions
    void OnTriggerEnter(Collider col){

		// problem reason : projectile dies before sound can be heard
		// fix : implement sound so that it does not die when projectile dies

//		if (col.gameObject.tag != "Player") {
//			audioSource.PlayOneShot (audioClip [1], 0.8f);
//		}


        if (col.gameObject.tag == tagToDamage){
			
			// Damage object with relevant tag
			HealthManager healthManager = col.gameObject.GetComponent<HealthManager>();
			healthManager.ApplyDamage(damageAmount);

			PlaySoundOneShot (bulletHitSound);

			MeshRenderer flash = col.GetComponentInChildren<MeshRenderer> ();

			Material originalMaterial = flash.material;

			flash.material = flashMaterial;

			// change it back after co-routine
			StartCoroutine (flashBlink(originalMaterial,flash));


        }

		//cannot damage these enemys
		if(col.gameObject.tag == tagUntouchableEnemys){

			PlaySoundOneShot (bulletHitUntouchableSound);

		}




		//cannot damage these enemys
		if(col.gameObject.tag == tagWallWhite){

			PlaySoundOneShot (bulletHitSound);

		}

		//cannot damage these enemys
		if(col.gameObject.tag == tagWallGrey){

			// Damage object with relevant tag
			HealthManager healthManager = col.gameObject.GetComponent<HealthManager>();
			healthManager.ApplyDamage(damageAmount);

			PlaySoundOneShot (bulletHitSound);

		}

    }

	// Hnadle sound effect playback (playOneShot) and Destroy obj after playback finishes
	void PlaySoundOneShot(int clip_index) {
		
		audioSource.pitch = 1;
		audioSource.PlayOneShot (audioClip [clip_index], 0.8f);

		MeshRenderer m = this.GetComponent<MeshRenderer> ();
		m.enabled = false;

		BoxCollider b = this.GetComponent<BoxCollider> ();
		b.enabled = false;

		// Destroy self
		Destroy(this.gameObject, audioClip [clip_index].length);

	}

	// Handle sound effect playback
	void PlaySound(int clip_index) {
		AudioSource audio = GetComponent<AudioSource> ();
		audio.clip = audioClip [clip_index];
		audio.Play ();
	}

}
