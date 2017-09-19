using System.Collections;
using System.Collections.Generic;
using UnityEngine;




/*

This class is to be drag and dropped on: Tutorial Panel 6

*/
public class tutorialSpawnEnemyScript : MonoBehaviour {


	//get the player, so you know where to spawn the move here area
	public GameObject player;

	//ground game object - need the boundaries of the map
	public GameObject ground;
	float groundSizeX;
	float groundSizeZ; 

	//instantiate a move here glowing pad, based on where player is 
	public GameObject enemy1_prefab; //prefab
	private GameObject enemy1; //prefab gameobject instance




	// Use this for initialization
	void Start () {

		//ground boundaries
		ground = GameObject.Find("Ground");
		Renderer groundSizeRenderer = ground.GetComponent<Renderer>();
		Vector3 groundSize = groundSizeRenderer.bounds.size;

		//divided by 2 for maths purposes (origin of ground is at 0,0 and largeset x is groundSize.x/2)
		groundSizeX = groundSize.x/2;
		groundSizeZ = groundSize.z/2;

		float spawnOffset = groundSizeX/3;

		player = GameObject.Find ("Player");

		Vector3 currentPlayerPos = player.transform.position;

		enemy1 = GameObject.Instantiate<GameObject>(enemy1_prefab);

		//want to spawn the glowing area in opposite x and z coordinates relative to the ground
		if (currentPlayerPos.x < 0 && currentPlayerPos.z < 0) { 
			enemy1.transform.position = new Vector3 (groundSizeX - spawnOffset , EnemyHeightScript.getEnemyHeight(enemy1) ,groundSizeZ - spawnOffset);

		} else if (currentPlayerPos.x < 0 && currentPlayerPos.z > 0) { 
			enemy1.transform.position = new Vector3 (groundSizeX - spawnOffset, EnemyHeightScript.getEnemyHeight(enemy1) ,-groundSizeZ + spawnOffset);

		} else if (currentPlayerPos.x > 0 && currentPlayerPos.z < 0) { 
			enemy1.transform.position = new Vector3 (-groundSizeX + spawnOffset, EnemyHeightScript.getEnemyHeight(enemy1) ,groundSizeZ - spawnOffset);

		}else if (currentPlayerPos.x > 0 &&  currentPlayerPos.z > 0){ 
			enemy1.transform.position = new Vector3 (-groundSizeX + spawnOffset, EnemyHeightScript.getEnemyHeight(enemy1),-groundSizeZ + spawnOffset);

		}

	}
	
	// Update is called once per frame
	void Update () {


		if (enemy1 == null) {
			

		}
	}
}
