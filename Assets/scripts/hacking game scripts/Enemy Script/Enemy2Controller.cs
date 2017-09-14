using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*Enemy2 - static , shoots towards player*/


public class Enemy2Controller : MonoBehaviour {


	public GameObject projectilePrefab;
	//cooldown variables
	public float PROJECTILE_COOLDOWN = 1.5f;// default max cooldown
	private float projectileCooldownCount;// count for the cooldown


	//want the enemy projectiles to aim at the player
	private GameObject player;

	void Start(){
		//assign the player here
		player = GameObject.Find("Player");

		projectileCooldownCount = PROJECTILE_COOLDOWN; //init cooldown count
	}

	// Update is called once per frame
	void Update () {



		HealthManager healthManager = this.gameObject.GetComponent<HealthManager>();
		MeshRenderer renderer = this.gameObject.GetComponent<MeshRenderer>();

		// Make enemy material darker based on its health
		renderer.material.color = Color.grey * ((float)healthManager.GetHealth() / 100.0f);

		//should put this in a method later ...
		if (projectileCooldownCount <= 0){

			GameObject projectile = Instantiate<GameObject>(projectilePrefab);

			//projectile will have the same position as enemy
			projectile.transform.position = this.gameObject.transform.position;

			//make projectile face the same direction as player----- or can do Random.Range(0,360)
			projectile.transform.LookAt (player.transform);
			//need the line of code below (y-90), since unity defines x (pointing right) axis as "facing forwards", but we want north to be "facing forwards"
			projectile.transform.eulerAngles = new Vector3 (0,projectile.transform.rotation.eulerAngles.y-90,0);


			//reset cooldown after you shoot 
			projectileCooldownCount = PROJECTILE_COOLDOWN;

		}

		if(projectileCooldownCount>0){
			projectileCooldownCount -= Time.deltaTime;
		}
	}


}
