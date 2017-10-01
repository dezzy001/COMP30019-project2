using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class triggerSpawnEnemy : MonoBehaviour {

	public string tagPlayer = "Player";

	public UnityEvent triggerEvent;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void activeEnemySpawnScript(GameObject levelScript){
		levelScript.SetActive (true);
	}

	// Handle collisions
	void OnTriggerEnter(Collider col){
		print ("trigger");
		if (col.gameObject.tag == tagPlayer){

			triggerEvent.Invoke ();

			Destroy(this.gameObject);


		}




	}

}
