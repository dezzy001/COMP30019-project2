using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileController : MonoBehaviour {

	public Vector3 velocity = new Vector3(8,0,0);
	public int damageAmount = 34; // default player projectile damage

	public string tagToDamage = "Player";

	//ground game object - need the boundaries of the map
	public GameObject ground;
	float groundSizeX;
	float groundSizeZ; 


	void Start(){
		//ground boundaries
		ground = GameObject.Find("Ground");
		Renderer groundSizeRenderer = ground.GetComponent<Renderer>();
		Vector3 groundSize = groundSizeRenderer.bounds.size;

		//divided by 2 for maths purposes (origin of ground is at 0,0 and largeset x is groundSize.x/2)
		groundSizeX = groundSize.x/2;
		groundSizeZ = groundSize.z/2;

	}

	// Update is called once per frame
	void Update () {
		this.transform.Translate(velocity * Time.deltaTime);

		if(this.transform.position.x > groundSizeX || this.transform.position.x < -groundSizeX 
			|| this.transform.position.z > groundSizeZ || this.transform.position.z < -groundSizeZ){

			Destroy(this.gameObject);

		}

	}

	// Handle collisions
	void OnTriggerEnter(Collider col)
	{

		if (col.gameObject.tag == tagToDamage){

			// Damage object with relevant tag
			HealthManager healthManager = col.gameObject.GetComponent<HealthManager>();
			healthManager.ApplyDamage(damageAmount);
			// Destroy self
			Destroy(this.gameObject);


		}
	}
}
