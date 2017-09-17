using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHereScript : MonoBehaviour {

	private string playerTag = "Player";

	public float DESTROY_WAIT = 0.01f;

	//on trigger for move to area
	// Handle collisions
	void OnTriggerEnter(Collider col){

		if (col.gameObject.tag == playerTag){

			StartCoroutine (destroyWait());

		}


	}


	IEnumerator destroyWait(){
		yield return new WaitForSeconds (DESTROY_WAIT);
		// Destroy self
		Destroy(this.gameObject);

	}

}
