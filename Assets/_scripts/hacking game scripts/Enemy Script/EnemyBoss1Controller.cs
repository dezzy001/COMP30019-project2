using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss1Controller : MonoBehaviour {

	/*Projectile variables*/
	public GameObject projectilePrefabStrong;
	public GameObject projectilePrefabWeak;

	//cooldown variables
	public float PROJECTILE_COOLDOWN = 0.2f; // default max cooldown
	private float projectileCooldownCount; // count for the cooldown

	public float DIST_FROM_PLAYER = 10.0f;

	//projectile spiral
	private float projectileSpiral1 = 0; // make the projectile come out in a spiral like pattern
	private float projectileSpiral2 = 90;
	private float projectileSpiral3 = 180;
	private float projectileSpiral4 = 270;
	public float spiralSpeed = 7.0f;

	//velocity of the enemys who can move
	public Vector3 velocity = new Vector3(1,0,0);

	//want the enemy projectiles to aim at the player
	private GameObject player;

	void Start(){

		//initialise untouchable tage
		gameObject.tag = "EnemyUntouchable"; 

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
		this.transform.eulerAngles = new Vector3 (0, this.transform.rotation.eulerAngles.y-90, 0);

		//if distance from player is relatively close, then stop moving
		float distanceFromPlayer = Vector3.Distance(this.transform.position , player.transform.position);

		if(distanceFromPlayer > DIST_FROM_PLAYER){
			this.transform.Translate(velocity * Time.deltaTime);
		}
			

		HealthManager healthManager = this.gameObject.GetComponent<HealthManager>();
		MeshRenderer renderer = this.gameObject.GetComponent<MeshRenderer>();

		// Make enemy material darker based on its health
		renderer.material.color = Color.grey *  ((float)healthManager.GetHealth() / 100.0f);


		//should put this in a method later ...
		if (projectileCooldownCount <= 0){

			int randomProjectilePrefab = Random.Range (0,2);
			GameObject projectilePrefab;


			if (randomProjectilePrefab == 1) {
				projectilePrefab = projectilePrefabStrong;

			} else {
				projectilePrefab = projectilePrefabWeak;

			}

			GameObject projectile1 = Instantiate<GameObject>(projectilePrefab);
			GameObject projectile2 = Instantiate<GameObject>(projectilePrefab);
			GameObject projectile3 = Instantiate<GameObject>(projectilePrefab);
			GameObject projectile4 = Instantiate<GameObject>(projectilePrefab);

			//size of projectiles - want to stick the projectile to the ground
			Vector3 projectileSize = projectile1.GetComponent<Collider>().bounds.size;
			float stickToGroundHeight = projectileSize.y / 2;

			//projectile will have the same position as enemy
			projectile1.transform.position = new Vector3(this.transform.position.x, stickToGroundHeight , this.transform.position.z);
			projectile2.transform.position= new Vector3(this.transform.position.x, stickToGroundHeight , this.transform.position.z);
			projectile3.transform.position = new Vector3(this.transform.position.x, stickToGroundHeight , this.transform.position.z);
			projectile4.transform.position = new Vector3(this.transform.position.x, stickToGroundHeight , this.transform.position.z);


			//have 4 spirals coming out of the boss
			projectile1.transform.eulerAngles = new Vector3 (0,projectileSpiral1,0);
			projectile2.transform.eulerAngles = new Vector3 (0,projectileSpiral2,0);
			projectile3.transform.eulerAngles = new Vector3 (0,projectileSpiral3,0);
			projectile4.transform.eulerAngles = new Vector3 (0,projectileSpiral4,0);


			//reset cooldown after you shoot 
			projectileCooldownCount = PROJECTILE_COOLDOWN;

		}

		if(projectileCooldownCount>0){
			projectileCooldownCount -= Time.deltaTime;
		}

		//variable which increments to allow a spiral pattern for the projectiles
		projectileSpiral1  += Time.deltaTime * spiralSpeed;
		projectileSpiral2  += Time.deltaTime * spiralSpeed;
		projectileSpiral3  += Time.deltaTime * spiralSpeed;
		projectileSpiral4  += Time.deltaTime * spiralSpeed;
		


	}
}
