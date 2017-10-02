using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Controller : MonoBehaviour {

	// when enemy is this distance or closer to player, stop moving
	public float DIST_FROM_PLAYER = 4.0f;

	// basic attributes of the enemy
	public float rotateSpeed = 10.0f;
	public float moveSpeed = 5.0f;
	public float gravity = 20.0f;

	private Vector3 moveDirection = Vector3.zero;
	private CharacterController controller;
	private GameObject player; // aim at the player

	// ground game object - need the boundaries of the map
	private GameObject ground;
	float groundSizeX;
	float groundSizeZ; 

	// projectile variables
	public GameObject projectilePrefab;
	public float PROJECTILE_COOLDOWN = 1.5f;// default max cooldown
	private float projectileCooldownCount;// count for the cooldown

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>(); // grab character controller
		player = GameObject.Find("Player");
		ground = GameObject.Find("Ground");


		this.transform.LookAt (player.transform);

		// ground boundaries
		Renderer groundSizeRenderer = ground.GetComponent<Renderer>();
		Vector3 groundSize = groundSizeRenderer.bounds.size;
		groundSizeX = groundSize.x/2;
		groundSizeZ = groundSize.z/2;

		// initialise weapon cooldown
		projectileCooldownCount = PROJECTILE_COOLDOWN;
	}

	// Update is called once per frame
	void Update () {

		// set rotation target
		var targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);

		// smoothly rotate towards the target point.
		transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * rotateSpeed);


		// compute distance from player
		float distanceFromPlayer = Vector3.Distance(this.transform.position , player.transform.position);

		var direction = Vector3.zero;

		if(distanceFromPlayer > DIST_FROM_PLAYER){
			// enemy is not close enough to player, proceed to move the enemy
			moveDirection = transform.forward;
			moveDirection *= moveSpeed;

			moveDirection.y -= gravity * Time.deltaTime;
			controller.Move (moveDirection * Time.deltaTime);
		}

		// stop the player from going out of bounds using clamp
		transform.position = new Vector3 (
			Mathf.Clamp(transform.position.x, -groundSizeX, groundSizeX),
			transform.position.y,
			Mathf.Clamp(transform.position.z, -groundSizeZ, groundSizeZ)
		);

		// attack player with projectile
		if (projectileCooldownCount <= 0){

			GameObject projectile = Instantiate<GameObject>(projectilePrefab);

			//size of projectiles - want to stick the projectile to the ground
			Vector3 projectileSize = projectile.GetComponent<Collider>().bounds.size;
			float stickToGroundHeight = projectileSize.y / 2;

			//projectile will have the same position as enemy
			projectile.transform.position = new Vector3(this.transform.position.x, stickToGroundHeight , this.transform.position.z);

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
