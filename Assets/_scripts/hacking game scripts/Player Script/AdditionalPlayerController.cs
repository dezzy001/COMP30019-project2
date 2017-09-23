using UnityEngine;
using System.Collections;

public class AdditionalPlayerController : MonoBehaviour {

	public float speed = 10.0f; // Default speed sensitivity
	public GameObject projectilePrefab;

	private HealthManager healthManager;
	private GameObject playerBodyLeft;
	private GameObject playerBodyRight;

	//cooldown variables
	//projectile
	public float PROJECTILE_COOLDOWN = 0.08f;// default max cooldown
	private float projectileCooldownCount;// count for the cooldown
	//invincibility
	public float INVINCIBILITY_COOLDOWN = 0.5f;// default max cooldown
	private float invincibilityCooldownCount = 0;// count for the cooldown


	private float PROJECTILE_OFFSET;

	//used for player direction, always facing mouse
	private Camera mainCamera;
	private Vector3 mousePosition;

	//rigid body of the player
	//private Rigidbody playerRigidBody;

	//character controller for the player
	private CharacterController controller;
	private Vector3 moveDirection = Vector3.zero;
	public float jumpSpeed = 8.0f;
	public float gravity = 0.0f;


	//ground game object - need the boundaries of the map
	private GameObject ground;
	float groundSizeX;
	float groundSizeZ; 


	//player controller - can disable any player movements you do not want  
	public bool allowMouseRotation = true; //rotation
	public bool allowMouseLeftClick = true; //shooting
	public bool allowKeypressMovement = true; //moving

	public ParticleSystem damangeRing;

	private bool gotHit1 = false;
	private bool gotHit2 = false;



	void Start(){

		//get the xyz values of this object
		Vector3 playerSize = this.GetComponent<Collider>().bounds.size;

		//projectile variables
		projectileCooldownCount = PROJECTILE_COOLDOWN; //init cooldown count
		PROJECTILE_OFFSET = playerSize.z;//offset for the projectile position relative to player

		//keep the player on the ground
		// this.gameObject.transform.position = new Vector3 (-5,playerSize.y/2,0);


		//apply a colour to the material of the mesh renderer component
		//MeshRenderer renderer = this.gameObject.GetComponent<MeshRenderer>();
		//renderer.material.color = Color.white;

		//assign the main camera to this variable
		mainCamera = FindObjectOfType<Camera> ();

		//assign the players rigid body to this variable
		//playerRigidBody = GetComponent<Rigidbody>();

		// assign the character controller
		controller = GetComponent<CharacterController> ();


		//ground boundaries
		GameObject ground = GameObject.Find("Ground");
		Renderer groundSizeRenderer = ground.GetComponent<Renderer>();
		Vector3 groundSize = groundSizeRenderer.bounds.size;

		//divided by 2 for maths purposes (origin of ground is at 0,0 and largeset x is groundSize.x/2)
		groundSizeX = groundSize.x/2;
		groundSizeZ = groundSize.z/2;

		//handle the health of the player here
		healthManager = this.gameObject.GetComponent<HealthManager>();
		//find the left and right body
		playerBodyLeft = GameObject.Find("Player/Player Spawn Particle System/playerleft");
		playerBodyRight = GameObject.Find("Player/Player Spawn Particle System/playerright");

	}



	// Update is called once per frame
	void Update () {

		// this.transform.localRotation *= Quaternion.AngleAxis(100 * Time.deltaTime, Vector3.up);

		//stop the player from going out of bounds
//		transform.position = new Vector3 (
//			Mathf.Clamp(transform.position.x,-groundSizeX,groundSizeX),
//			transform.position.y,
//			Mathf.Clamp(transform.position.z,-groundSizeZ,groundSizeZ)
//		);

		//move the player with key presses
		//Vector3 move;
		if(allowKeypressMovement == true){
			//move = getKeyPress ();

			// try move the player with the character controller methods
			moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
			moveDirection *= speed;
			moveDirection.y -= gravity * Time.deltaTime;
			controller.Move (moveDirection * Time.deltaTime);
		}

		//this.transform.position = Vector3.Lerp(transform.position, transform.position + move, speed * Time.deltaTime);


		//followed this tutorial to make player face mouse, based on camera rays: https://www.youtube.com/watch?v=lkDGk3TjsIE
		Ray cameraRay = mainCamera.ScreenPointToRay (Input.mousePosition);
		Plane groundPlane = new Plane (Vector3.up, Vector3.zero);
		float rayLength;

		//if not paused
		if(groundPlane.Raycast(cameraRay, out rayLength) &&  Time.timeScale == 1){

			Vector3 pointToLook = cameraRay.GetPoint (rayLength);
			Debug.DrawLine (cameraRay.origin, pointToLook,Color.blue);

			Vector3 pointToLookXZfixed = new Vector3 (pointToLook.x , transform.position.y, pointToLook.z);

			if(allowMouseRotation == true){
				// transform.LookAt (pointToLookXZfixed);
			}






			//should put this in a method later ...

			if (Input.GetMouseButton(0) && projectileCooldownCount <= 0 && allowMouseLeftClick == true){
				GameObject projectile = Instantiate<GameObject>(projectilePrefab);

				//offset the position of the projectile in front of the player (rather then inside)
				Vector3 spawnPos = this.transform.position + this.transform.forward * PROJECTILE_OFFSET;

				//projectile will have the same position as player
				projectile.transform.position = spawnPos;

				//make projectile face the same direction as player
				//need the line of code below (y-90) unitys definition of facing forward is x axis, so need to subtract by 90 to make z axis be "facing forward"
				Vector3 playerDir = new Vector3 (0.0f, this.gameObject.transform.rotation.eulerAngles.y-90 ,0.0f);
				projectile.transform.eulerAngles = playerDir ;


				//reset cooldown after you shoot 
				projectileCooldownCount = PROJECTILE_COOLDOWN;

			}




			//player health animations here----

			//activate invincibility when hit
			//destory left body part
			if(this.healthManager.GetHealth() < 70 && (gotHit1 == false)){
				//add invincibility here


				damangeRing.Play ();
				gotHit1 = true;

				playerBodyLeft.SetActive (false);


				//activate invincibility 
				invincibilityCooldownCount = INVINCIBILITY_COOLDOWN;

			}


			//destory right body part
			if(this.healthManager.GetHealth() < 40 && (gotHit2 == false)){
				//add invincibility here

				damangeRing.Play ();
				gotHit2 = true;

				playerBodyRight.SetActive (false);

				//activate invincibility 
				invincibilityCooldownCount = INVINCIBILITY_COOLDOWN;
			}


			//invincibility, if the cool down is greater than zero, then give player invincibility
			if (gotHit1 && invincibilityCooldownCount > 0) {
				this.gameObject.tag = "Untagged";
			} else {

				this.gameObject.tag = "Player";
			}




			//decrement the cooldown variables
			if(projectileCooldownCount > 0){
				projectileCooldownCount -= Time.deltaTime;
			}

			if(invincibilityCooldownCount > 0){
				invincibilityCooldownCount -= Time.deltaTime;
			}


		}
	}


	//makes player go invincible by changing its tag to untagged for a specified time
	public void goInvincible(){



	}


	/*
	private Vector3 getKeyPress(){


		Vector3 velocity = new Vector3 (0.0f,0.0f,0.0f);


		if (Input.GetKey(KeyCode.A) ||  Input.GetKey(KeyCode.LeftArrow)){
			velocity += new Vector3(-1.0f,0.0f,0.0f);
		}

		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
			velocity += new Vector3(1.0f,0.0f,0.0f);
		}
			

		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)){
			velocity += new Vector3(0.0f,0.0f,1.0f) ;
		}
		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)){
			velocity += new Vector3(0.0f,0.0f,-1.0f) ;
		}



		return velocity;

	}
	*/


}
