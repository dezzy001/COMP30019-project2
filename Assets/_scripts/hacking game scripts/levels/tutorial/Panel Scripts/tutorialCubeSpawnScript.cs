using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*

This class is to be drag and dropped on: Tutorial Panel 3A

*/
public class tutorialCubeSpawnScript : TutorialSwitchPanelScript {

	//ground game object - need the boundaries of the map
	public GameObject ground;
	float groundSizeX;
	float groundSizeZ; 

	//instantiate a move here glowing pad, based on where player is 
	public GameObject cube_prefab; //prefab
	private GameObject cube1; //prefab gameobject instance
	private GameObject cube2;
	private GameObject cube3;
	private GameObject cube4;

	public GameObject thisPanel;
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

		float spawnOffset = groundSizeX/5;


		cube1 = GameObject.Instantiate<GameObject>(cube_prefab);
		float cubeHeight = EnemyHeightScript.getEnemyHeight(cube1);

		cube1.transform.position = new Vector3 (0 , cubeHeight ,-groundSizeZ + spawnOffset);

		cube2 = GameObject.Instantiate<GameObject>(cube_prefab);
		cube2.transform.position = new Vector3 (0 , cubeHeight ,groundSizeZ - spawnOffset);

		cube3 = GameObject.Instantiate<GameObject>(cube_prefab);
		cube3.transform.position = new Vector3 (-groundSizeX + spawnOffset , cubeHeight ,0);

		cube4 = GameObject.Instantiate<GameObject>(cube_prefab);
		cube4.transform.position = new Vector3 (groundSizeX - spawnOffset , cubeHeight ,0);


	}

	// Update is called once per frame
	void Update () {

		TutorialScript.movePanelToBottom (thisPanel , 500, 0);

		if (cube1 == null && cube2 == null && cube3 == null && cube4 == null ) {
			StartCoroutine (delayBeforeNextTutorial(nextPanel,  DELAY_B4_NEXT_TUT));
		}
	}



}
