using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCubeScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		HealthManager healthManager = this.gameObject.GetComponent<HealthManager>();
		MeshRenderer renderer = this.gameObject.GetComponentInChildren<MeshRenderer>();

		// Make enemy material darker based on its health
		if(renderer != null){
			renderer.material.color = Color.white * ((float)healthManager.GetHealth() / 100.0f);

		}
	}
}
