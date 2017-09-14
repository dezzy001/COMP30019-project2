using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*Enemy1 - moves and shoots in players direction */

public class Enemy1Controller : MonoBehaviour {


	public GameObject projectilePrefab;
	//cooldown variables
	public float PROJECTILE_COOLDOWN = 1.5f;// default max cooldown
	private float projectileCooldownCount;// count for the cooldown

	//velocity of the enemys who can move
	public Vector3 velocity = new Vector3(5,0,0);

	//want the enemy projectiles to aim at the player
	private GameObject player;

	void Start(){
		//assign the player here
		player = GameObject.Find("Player");

		projectileCooldownCount = PROJECTILE_COOLDOWN; //init cooldown count
	}

	// Update is called once per frame
	void Update () {

		//move the enemy towards the player

		//make enemy face the same direction as player
		this.transform.LookAt (player.transform);
		//need the line of code below, for some reason we need to rotate by -90 
		this.transform.eulerAngles = new Vector3 (0,this.transform.rotation.eulerAngles.y-90,0);

		this.transform.Translate(velocity * Time.deltaTime);



		HealthManager healthManager = this.gameObject.GetComponent<HealthManager>();
		MeshRenderer renderer = this.gameObject.GetComponent<MeshRenderer>();

		// Make enemy material darker based on its health
		renderer.material.color = Color.red * ((float)healthManager.GetHealth() / 100.0f);

		//should put this in a method later ...
		if (projectileCooldownCount <= 0){

			GameObject projectile = Instantiate<GameObject>(projectilePrefab);

			//projectile will have the same position as enemy
			projectile.transform.position = this.gameObject.transform.position;

			//make projectile face the same direction as player----- or can do Random.Range(0,360)
			projectile.transform.LookAt (player.transform);
			//need the line of code below, for some reason we need to rotate by -90 
			projectile.transform.eulerAngles = new Vector3 (0,projectile.transform.rotation.eulerAngles.y-90,0);


			//reset cooldown after you shoot 
			projectileCooldownCount = PROJECTILE_COOLDOWN;

		}

		if(projectileCooldownCount>0){
			projectileCooldownCount -= Time.deltaTime;
		}
	}


}
