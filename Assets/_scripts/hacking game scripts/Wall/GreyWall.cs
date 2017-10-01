using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreyWall : MonoBehaviour {

	// Use this for initialization
	void Start () {

		HealthManager healthManager = this.gameObject.GetComponent<HealthManager> ();
		//MeshRenderer renderer = this.gameObject.GetComponentInChildren<MeshRenderer> ();
		//renderer.material.color = new Color(0.3f,0.3f,0.3f) ;
	}


	// Update is called once per frame
	void Update () {
		
	}

}
