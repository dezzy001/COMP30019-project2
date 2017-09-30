using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDeathEvent : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void enemyDeath(){
		Destroy(this.gameObject);
	}
}
