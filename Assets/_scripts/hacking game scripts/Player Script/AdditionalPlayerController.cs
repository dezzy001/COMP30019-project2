using UnityEngine;
using System.Collections;

public class AdditionalPlayerController : MonoBehaviour {

	public float speed = 10.0f; // Default speed sensitivity
	public GameObject projectilePrefab;

	//cooldown variables
	//projectile
	public float PROJECTILE_COOLDOWN = 0.08f;// default max cooldown
	private float projectileCooldownCount;// count for the cooldown

	private float PROJECTILE_OFFSET;

	//rigid body of the player
	//private Rigidbody playerRigidBody;


	//ground game object - need the boundaries of the map
	private GameObject ground;

	//player controller - can disable any player movements you do not want  
	public PlayerController playerControllerScript;




	void Start(){

		//get the xyz values of this object
		Vector3 playerSize = this.GetComponent<Collider>().bounds.size;

		//projectile variables
		projectileCooldownCount = PROJECTILE_COOLDOWN; //init cooldown count
		PROJECTILE_OFFSET = playerSize.z;//offset for the projectile position relative to player

		//ground boundaries
		GameObject ground = GameObject.Find("Ground");
		Renderer groundSizeRenderer = ground.GetComponent<Renderer>();
		Vector3 groundSize = groundSizeRenderer.bounds.size;

		playerControllerScript = GameObject.Find ("Player").GetComponent<PlayerController>();

	}



	// Update is called once per frame
	void Update () {





			//should put this in a method later ...

		if (Input.GetMouseButton(0) && projectileCooldownCount <= 0 && playerControllerScript.allowMouseLeftClick == true){
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

			//decrement the cooldown variables
			if(projectileCooldownCount > 0){
				projectileCooldownCount -= Time.deltaTime;
			}
				



	}





}
