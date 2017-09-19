using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*

This class is to be drag and dropped on: Tutorial Panel 5A

*/

public class tutorialMoveToAreaScript : MonoBehaviour {

	//get the player, so you know where to spawn the move here area
	public GameObject player;

	//ground game object - need the boundaries of the map
	public GameObject ground;
	float groundSizeX;
	float groundSizeZ; 

	//instantiate a move here glowing pad, based on where player is 
	public GameObject moveHereParticles_prefab; //prefab
	private GameObject moveHereParticles; //prefab gameobject instance


	public GameObject nextPanel;

	public float DELAY_B4_NEXT_TUT = 0.35f;


	// Use this for initialization
	void Start () {

		//ground boundaries
		ground = GameObject.Find("Ground");
		Renderer groundSizeRenderer = ground.GetComponent<Renderer>();
		Vector3 groundSize = groundSizeRenderer.bounds.size;

		//divided by 2 for maths purposes (origin of ground is at 0,0 and largeset x is groundSize.x/2)
		groundSizeX = groundSize.x/2;
		groundSizeZ = groundSize.z/2;

		float spawnOffset = groundSizeX/5;

		player = GameObject.Find ("Player");

		Vector3 currentPlayerPos = player.transform.position;

		moveHereParticles = GameObject.Instantiate<GameObject>(moveHereParticles_prefab);

		//want to spawn the glowing area in opposite x and z coordinates relative to the ground
		if (currentPlayerPos.x < 0 && currentPlayerPos.z < 0) { 
			moveHereParticles.transform.position = new Vector3 (groundSizeX - spawnOffset ,0.3f,groundSizeZ - spawnOffset);

		} else if (currentPlayerPos.x < 0 && currentPlayerPos.z > 0) { 
			moveHereParticles.transform.position = new Vector3 (groundSizeX - spawnOffset,0.3f,-groundSizeZ + spawnOffset);

		} else if (currentPlayerPos.x > 0 && currentPlayerPos.z < 0) { 
			moveHereParticles.transform.position = new Vector3 (-groundSizeX + spawnOffset,0.3f,groundSizeZ - spawnOffset);

		}else if (currentPlayerPos.x > 0 &&  currentPlayerPos.z > 0){ 
			moveHereParticles.transform.position = new Vector3 (-groundSizeX + spawnOffset,0.3f,-groundSizeZ + spawnOffset);

		}

	}
	
	// Update is called once per frame
	void Update () {

		if(moveHereParticles == null ){
			//print ("destroyed");
			StartCoroutine(delayBeforeNextTutorial());
		}
	}
		


	IEnumerator delayBeforeNextTutorial(){
		
		yield return new WaitForSeconds (DELAY_B4_NEXT_TUT);

		nextPanel.SetActive (true);
		this.gameObject.SetActive (false);
	}


}
