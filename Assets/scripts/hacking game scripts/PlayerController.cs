using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed = 10.0f; // Default speed sensitivity
    public GameObject projectilePrefab;


	//cooldown variables
	public float PROJECTILE_COOLDOWN = 0.5f;// default max cooldown
	private float projectileCooldownCount;// count for the cooldown

	//used for player movement
	private Vector3 moveInput;
	private Vector3 moveVelocity;

	//used for player direction, always facing mouse
	private Camera mainCamera;
	private Vector3 mousePosition;

	//rigid body of the player
	private Rigidbody playerRigidBody;

	void Start(){

		projectileCooldownCount = PROJECTILE_COOLDOWN; //init cooldown count

		//apply a colour to the material of the mesh renderer component
		MeshRenderer renderer = this.gameObject.GetComponent<MeshRenderer>();
		renderer.material.color = Color.white;

		//assign the main camera to this variable
		mainCamera = FindObjectOfType<Camera> ();
		//assign the players rigid body to this variable
		playerRigidBody = GetComponent<Rigidbody>();

	}

	// Update is called once per frame
	void Update () {

		//2 different ways of player movement (1 and 2 currently do not consider which way the player is facing)

		//### 1
		Vector3 keyDirection = getKeyPress ();
		this.transform.Translate(keyDirection * speed * Time.deltaTime);

		//### 2
		//lerp could be smoother?
		//transform.position = Vector3.Lerp(transform.position, transform.position+keyDirection, speed * Time.deltaTime);


		//followed this tutorial to make player face mouse, based on camera: https://www.youtube.com/watch?v=lkDGk3TjsIE
		Ray cameraRay = mainCamera.ScreenPointToRay (Input.mousePosition);
		Plane groundPlane = new Plane (Vector3.up, Vector3.zero);
		float rayLength;

		if(groundPlane.Raycast(cameraRay, out rayLength)){

			Vector3 pointToLook = cameraRay.GetPoint (rayLength);
			Debug.DrawLine (cameraRay.origin, pointToLook,Color.blue);

			Vector3 pointToLookXZfixed = new Vector3 (pointToLook.x, transform.position.y, pointToLook.z);

			transform.LookAt (pointToLookXZfixed);



			//should put this in a method later ...

			if (Input.GetMouseButton(0) && projectileCooldownCount <= 0){//use GetKeyDown instead if you dont want the player to be able to hold the space bar
				GameObject projectile = Instantiate<GameObject>(projectilePrefab);

				//projectile will have the same position and face the same way as player
				projectile.transform.position = this.gameObject.transform.position;

				//HELP: need to make projectile face the same direction as player... semi solution
				Vector3 playerDir = new Vector3 (0.0f, this.gameObject.transform.rotation.eulerAngles.y-90,0.0f);
				projectile.transform.eulerAngles = playerDir ;


				//reset cooldown after you shoot 
				projectileCooldownCount = PROJECTILE_COOLDOWN;

			}


			if(projectileCooldownCount>0){
				projectileCooldownCount -= Time.deltaTime;
			}

		}







    }




	private Vector3 getKeyPress(){


		Vector3 velocity = new Vector3 (0.0f,0.0f,0.0f);

		/* Only makes sense to make player move forwards and backwards (use mouse to control left and right movements)
		 * 
		if (Input.GetKey(KeyCode.LeftArrow)){
			velocity += new Vector3(-1.0f,0.0f,0.0f);
		}

		if (Input.GetKey(KeyCode.RightArrow)){
			velocity += new Vector3(1.0f,0.0f,0.0f);
		}


		*/

		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)){
			velocity += new Vector3(0.0f,0.0f,1.0f) ;
		}
		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)){
			velocity += new Vector3(0.0f,0.0f,-1.0f) ;
		}



		return velocity;

	}

}
