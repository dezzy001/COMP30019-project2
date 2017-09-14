using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed = 10.0f; // Default speed sensitivity
    public GameObject projectilePrefab;


	//cooldown variables
	public float PROJECTILE_COOLDOWN = 0.5f;// default max cooldown
	private float projectileCooldownCount;// count for the cooldown

	//used for player movement
	//private Vector3 moveInput;
	//private Vector3 moveVelocity;

	//used for player direction, always facing mouse
	private Camera mainCamera;
	private Vector3 mousePosition;

	//rigid body of the player
	private Rigidbody playerRigidBody;

	//ground game object - need the boundaries of the map
	public GameObject ground;
	float groundSizeX;
	float groundSizeZ; 

	void Start(){

		this.gameObject.transform.position = new Vector3 (0,1,0);

		projectileCooldownCount = PROJECTILE_COOLDOWN; //init cooldown count

		//apply a colour to the material of the mesh renderer component
		MeshRenderer renderer = this.gameObject.GetComponent<MeshRenderer>();
		renderer.material.color = Color.white;

		//assign the main camera to this variable
		mainCamera = FindObjectOfType<Camera> ();
		//assign the players rigid body to this variable
		playerRigidBody = GetComponent<Rigidbody>();

		//ground boundaries
		Renderer groundSizeRenderer = ground.GetComponent<Renderer>();
		Vector3 groundSize = groundSizeRenderer.bounds.size;

		//divided by 2 for maths purposes (origin of ground is at 0,0 and largeset x is groundSize.x/2)
		groundSizeX = groundSize.x/2;
		groundSizeZ = groundSize.z/2;



	}

	// Update is called once per frame
	void Update () {


		//stop the player from going out of bounds
		transform.position = new Vector3 (
			Mathf.Clamp(transform.position.x,-groundSizeX,groundSizeX),
			transform.position.y,
			Mathf.Clamp(transform.position.z,-groundSizeZ,groundSizeZ)
		);

	
		//move the player with key presses
		Vector3 move = getKeyPress ();
		this.transform.position = Vector3.Lerp(transform.position, transform.position + move, speed * Time.deltaTime);

		//followed this tutorial to make player face mouse, based on camera rays: https://www.youtube.com/watch?v=lkDGk3TjsIE
		Ray cameraRay = mainCamera.ScreenPointToRay (Input.mousePosition);
		Plane groundPlane = new Plane (Vector3.up, Vector3.zero);
		float rayLength;

		if(groundPlane.Raycast(cameraRay, out rayLength)){

			Vector3 pointToLook = cameraRay.GetPoint (rayLength);
			Debug.DrawLine (cameraRay.origin, pointToLook,Color.blue);

			Vector3 pointToLookXZfixed = new Vector3 (pointToLook.x, transform.position.y, pointToLook.z);

			transform.LookAt (pointToLookXZfixed);



			//should put this in a method later ...

			if (Input.GetMouseButton(0) && projectileCooldownCount <= 0){
				GameObject projectile = Instantiate<GameObject>(projectilePrefab);

				//projectile will have the same position as player
				projectile.transform.position = this.gameObject.transform.position;

				//make projectile face the same direction as player
				//need the line of code below (y-90), since unity defines x (pointing right) axis as "facing forwards", but we want north to be "facing forwards"
				Vector3 playerDir = new Vector3 (0.0f, this.gameObject.transform.rotation.eulerAngles.y-90 ,0.0f);
				projectile.transform.eulerAngles = playerDir ;

				//Debug.Log (playerDir);

				//reset cooldown after you shoot 
				projectileCooldownCount = PROJECTILE_COOLDOWN;

			}
				
			if(projectileCooldownCount>0){
				projectileCooldownCount -= Time.deltaTime;
			}

		}




		//handle the health of the player here
		HealthManager healthManager = this.gameObject.GetComponent<HealthManager>();
		MeshRenderer renderer = this.gameObject.GetComponent<MeshRenderer>();

		// Make enemy material darker based on its health
		renderer.material.color = Color.white * ((float)healthManager.GetHealth() / 100.0f);



    }




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



}
