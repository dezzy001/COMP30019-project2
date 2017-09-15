using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekingEnemyProjectile : EnemyProjectileController {

	//want the enemy projectiles to aim at the player
	private GameObject player;

	private float ROTATE_90DEG = 90;

	void Start(){
		//assign the player here
		player = GameObject.Find("Player");


	}
	
	// Update is called once per frame
	void Update () {
		
		//move the enemy towards the player

		//make enemy face the same direction as player
		this.transform.LookAt (player.transform);
		//need the line of code below, for some reason we need to rotate by -90 
		this.transform.eulerAngles = new Vector3 (ROTATE_90DEG,this.transform.rotation.eulerAngles.y-90,0);

		this.transform.Translate(velocity * Time.deltaTime);
	}
}
