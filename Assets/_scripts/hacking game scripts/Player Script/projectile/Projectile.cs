using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	/*Tags*/
	public string tagToDamage = "Enemy";
	public string tagUntouchableEnemys = "EnemyUntouchable";
	public string tagWallWhite =  "Wallwhite";
	public string tagWallGrey = "Wallgrey";

	public AudioSource audioSource;
	public AudioClip[] audioClip;

	public float timeToLive;

	protected int laserFireSound = 0;
	protected int bulletHitSound = 1;
	protected int bulletHitUntouchableSound = 2;

	//flash animation using glow material
	public Material flashMaterial;

	// public Material enemyMaterial;
	public float FLASH_WAIT = 1.0f;

	public int damageAmount;



	// Handle collisions
	public void OnTriggerEnter(Collider col){

		if (col.gameObject.tag == tagToDamage){

			// Damage object with relevant tag
			HealthManager healthManager = col.gameObject.GetComponent<HealthManager>();
			healthManager.ApplyDamage(damageAmount);

			PlaySoundOneShot (bulletHitSound);
			flashWhenHit (col);

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
			flashWhenHit (col);

		}

	}

	IEnumerator flashBlink(Material originalMaterial, MeshRenderer singleFlash){

		yield return new WaitForSeconds (FLASH_WAIT);

		if (singleFlash != null) {
			singleFlash.sharedMaterial = originalMaterial;
			print (originalMaterial == flashMaterial);
		}

	}

	//make the enemy flash when hit
	public void flashWhenHit(Collider col){
		// grab the mesh renderer component from the object which is hit by player projectile
		MeshRenderer[] flash = col.GetComponentsInChildren<MeshRenderer> ();


		foreach (MeshRenderer singleFlash in flash) {
			

			if (singleFlash.sharedMaterial != flashMaterial) {

				// grab the original material and store it for later restoration purpose
				Material originalMaterial = singleFlash.sharedMaterial;

				singleFlash.sharedMaterial = null;

				singleFlash.sharedMaterial = flashMaterial;

				// change it back after co-routine
				StartCoroutine (flashBlink (originalMaterial, singleFlash));

			} else {
				singleFlash.material.color = Color.grey;
			}

		}
	}


	// Handle sound effect playback (playOneShot) and Destroy obj after playback finishes
	public virtual void PlaySoundOneShot(int clip_index) {

		audioSource.pitch = 1;
		audioSource.PlayOneShot (audioClip [clip_index], 0.8f);

	}



	// Handle sound effect playback
	public void PlaySound(int clip_index) {
		AudioSource audio = GetComponent<AudioSource> ();
		audio.clip = audioClip [clip_index];
		audio.Play ();
	}




}
