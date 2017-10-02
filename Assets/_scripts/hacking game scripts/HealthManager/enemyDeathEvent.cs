using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDeathEvent : MonoBehaviour {


	public ParticleSystem enemyOnDeathParticle_prefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void enemyDeath(){
		
		Instantiate (enemyOnDeathParticle_prefab,this.transform.position, enemyOnDeathParticle_prefab.transform.rotation);


		Destroy(this.gameObject);

	}
}
