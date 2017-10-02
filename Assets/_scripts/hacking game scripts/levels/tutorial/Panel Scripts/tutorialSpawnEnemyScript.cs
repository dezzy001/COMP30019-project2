using System.Collections;
using System.Collections.Generic;
using UnityEngine;




/*

This class is to be drag and dropped on: Tutorial Panel 6

*/
public class tutorialSpawnEnemyScript : TutorialSwitchPanelScript {


	//get the player, so you know where to spawn the move here area
	public GameObject player;

	//ground game object - need the boundaries of the map
	public GameObject ground;
	float groundSizeX;
	float groundSizeZ; 

	//instantiate a move here glowing pad, based on where player is 
	public GameObject enemy1_prefab; //prefab
	private GameObject enemy1; //prefab gameobject instance
	private bool enemy1Spawned = false;

	public GameObject panelToHide;

	public float DELAY_B4_NEXT_TUT = 0.35f;
	public GameObject nextPanel;



	// Use this for initialization
	void Start () {

		//ground boundaries
		ground = GameObject.Find("Ground");
		Renderer groundSizeRenderer = ground.GetComponent<Renderer>();
		Vector3 groundSize = groundSizeRenderer.bounds.size;

		//divided by 2 for maths purposes (origin of ground is at 0,0 and largeset x is groundSize.x/2)
		groundSizeX = groundSize.x/2;
		groundSizeZ = groundSize.z/2;

		float spawnOffset = groundSizeX*3/5;

		player = GameObject.Find ("Player");
		//allow player movement again, since we disabled it when they stepped onto the glowing area
		player.GetComponent<PlayerController> ().allowKeypressMovement = true;


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

		enemy1.tag = "Untagged";


	}
	
	// Update is called once per frame
	void Update () {


		//proper spawning sequence
		GameObject enemyBodyPart = GameObject.Find ("enemy1(Clone)/enemy1_cube");

		if(enemyBodyPart != null && enemyBodyPart.activeSelf == true && !enemy1Spawned){
			//pause the game when the enemy has spawned on the ground
			Time.timeScale = 0;
			enemy1.tag = "Enemy";
			enemy1Spawned = true;
		}

		if(enemyBodyPart != null && Input.GetMouseButtonDown(0) && enemyBodyPart.activeSelf == true){
			//unpause when player starts shooting, and hide the current text panel
			panelToHide.SetActive (false);
			Time.timeScale = 1;
		}



		//print (enemy1 == null);
		if (enemy1 == null) {
			//print ("enemy destroyed");
			StartCoroutine (delayBeforeNextTutorial (nextPanel, DELAY_B4_NEXT_TUT));

		}


	}
}
