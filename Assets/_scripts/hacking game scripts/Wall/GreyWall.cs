using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreyWall : MonoBehaviour {

	// Use this for initialization
	void Start () {

		HealthManager healthManager = this.gameObject.GetComponent<HealthManager> ();
		//MeshRenderer renderer = this.gameObject.GetComponentInChildren<MeshRenderer> ();
		//renderer.material.color = new Color(0.3f,0.3f,0.3f) ;

		//y height of the enemy
		float sizeY = this.GetComponent<Collider>().bounds.size.y;

		// initialise enemy y position at the ground
		this.transform.position = new Vector3(this.transform.position.x, sizeY/2, this.transform.position.z);
	}


	// Update is called once per frame
	void Update () {
		
	}

}
