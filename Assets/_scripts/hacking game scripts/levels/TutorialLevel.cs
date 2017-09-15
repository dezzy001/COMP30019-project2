using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialLevel : MonoBehaviour {

	//when game complete show the hacking complete panel
	public GameObject hackingCompletePanel;
	private bool gameStarted = false;
	private float HACKING_PANEL_WAIT = 0.3f;


	//number of enemys 
	public int enemyRows = 1;
	public int enemyCols = 1;



	//enemy prefabs
	public GameObject enemy1_prefab;


	//enemy sizes
	private Vector3 enemy1Size;


	//ground game object - need the boundaries of the map
	public GameObject ground;
	float groundSizeX;
	float groundSizeZ; 

	// Use this for initialization
	void Start () {

		hackingCompletePanel.SetActive(false);

		//ground boundaries
		Renderer groundSizeRenderer = ground.GetComponent<Renderer>();
		Vector3 groundSize = groundSizeRenderer.bounds.size;

		//divided by 2 for maths purposes (origin of ground is at 0,0 and largeset x is groundSize.x/2)
		groundSizeX = groundSize.x/2;
		groundSizeZ = groundSize.z/2;

		//make the offset of the spawn from the bottom left corner of the map
		this.transform.position = new Vector3 (-groundSizeX,0,-groundSizeZ);

		//click panel to generate enemy
		//generateEnemy ();

	}

	// Update is called once per frame
	void Update () {
		if(gameStarted == true){
			if(transform.childCount == 0){

				StartCoroutine (showHackingPanel());


			}

		}

	}

	//generate enemys in a row and column
	public void generateEnemy(){

		gameStarted = true;

		GameObject enemy = GameObject.Instantiate<GameObject> (enemy1_prefab);

		//size of enemy1_prefab
		Vector3 enemy1Size = enemy.GetComponent<BoxCollider>().bounds.size;

		enemy.transform.parent = this.transform;
		enemy.transform.localPosition = new Vector3 (0,0,0);

		//need to move this enemys y position up a little 
		enemy.transform.localPosition = new Vector3 (enemy.transform.localPosition.x, enemy1Size.y/2 ,enemy.transform.localPosition.z);


	}


	IEnumerator showHackingPanel(){


		//wait for 1 second before showing hacking panel and the cursour
		yield return new WaitForSeconds (HACKING_PANEL_WAIT);

		hackingCompletePanel.SetActive(hackingCompletePanel);
		Cursor.visible = true;

	}




}
