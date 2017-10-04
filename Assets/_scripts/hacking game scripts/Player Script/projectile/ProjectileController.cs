using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProjectileController : Projectile {

	public Vector3 velocity = new Vector3(40,0,0);


	void Start(){

		audioSource = GetComponent<AudioSource> ();

		// Play the laser firing sound
		audioSource.PlayOneShot (audioClip [laserFireSound], 0.8f);

	}

    // Update is called once per frame
    void Update () {

        this.transform.Translate(velocity * Time.deltaTime);

		timeToLive -= Time.deltaTime;

		if (timeToLive <= 0.0f) {
			Destroy (this.gameObject);
		}

	}

	// Hnadle sound effect playback (playOneShot) and Destroy obj after playback finishes
	public override void PlaySoundOneShot(int clip_index) {

		audioSource.pitch = 1;
		audioSource.PlayOneShot (audioClip [clip_index], 0.8f);

		MeshRenderer m = this.GetComponent<MeshRenderer> ();
		m.enabled = false;

		BoxCollider b = this.GetComponent<BoxCollider> ();
		b.enabled = false;

		// Destroy self
		Destroy(this.gameObject, audioClip [clip_index].length);

	}

}
