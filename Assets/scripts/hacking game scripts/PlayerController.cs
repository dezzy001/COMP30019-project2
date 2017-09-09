using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed = 10.0f; // Default speed sensitivity
    public GameObject projectilePrefab;

	public float PROJECTILE_COOLDOWN = 0.5f;// default max cooldown
	private float projectileCooldownCount;// count for the cooldown

	void Start(){

		projectileCooldownCount = PROJECTILE_COOLDOWN; //init cooldown count

		//apply a colour to the material of the mesh renderer component
		MeshRenderer renderer = this.gameObject.GetComponent<MeshRenderer>();
		renderer.material.color = Color.white;
	}

	// Update is called once per frame
	void Update () {

		Vector3 keyDirection = getKeyPress ();


		this.transform.Translate(keyDirection * speed * Time.deltaTime);


		if (Input.GetKey(KeyCode.Space) && projectileCooldownCount <= 0){//use GetKeyDown instead if you dont want the player to be able to hold the space bar
            GameObject projectile = Instantiate<GameObject>(projectilePrefab);
            projectile.transform.position = this.gameObject.transform.position;
			projectileCooldownCount = PROJECTILE_COOLDOWN;
        	
		}
        

		if(projectileCooldownCount>0){
			projectileCooldownCount -= Time.deltaTime;
		}


    }


	private Vector3 getKeyPress(){

		//need to store a previous direction variable, so we know how to rotate player, to ensure it faces correct direction

		Vector3 velocity = new Vector3 (0.0f,0.0f,0.0f);

		if (Input.GetKey(KeyCode.LeftArrow)){
			velocity += new Vector3(-1.0f,0.0f,0.0f);
		}

		if (Input.GetKey(KeyCode.RightArrow)){
			velocity += new Vector3(1.0f,0.0f,0.0f);
		}

		if (Input.GetKey(KeyCode.UpArrow)){
			velocity += new Vector3(0.0f,0.0f,1.0f) ;
		}

		if (Input.GetKey(KeyCode.DownArrow)){
			velocity += new Vector3(0.0f,0.0f,-1.0f) ;
		}

		return velocity;

	}

}
