using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour {


	//when game complete show the hacking complete panel
	public GameObject hackingCompletePanel;
	private bool gameStarted = false;
	private float HACKING_PANEL_WAIT = 0.3f;


	//number of enemys 
	public int enemyRows = 2;
	public int enemyCols = 2;
	public float enemySpacing;


	//enemy prefabs
	public GameObject enemy1_prefab;
	public GameObject enemy2_prefab;
	public GameObject enemyBoss1_prefab;

	//enemy sizes
	private Vector3 enemy1Size;
	private Vector3 enemy2Size;
	private Vector3 enemyBoss1Size;


	//ground game object - need the boundaries of the map
	public GameObject ground;
	float groundSizeX;
	float groundSizeZ; 

	// Use this for initialization
	void Start () {

		hackingCompletePanel.SetActive(false);

		//ground boundaries
		ground = GameObject.Find("Ground");
		Renderer groundSizeRenderer = ground.GetComponent<Renderer>();
		Vector3 groundSize = groundSizeRenderer.bounds.size;

		//divided by 2 for maths purposes (origin of ground is at 0,0 and largeset x is groundSize.x/2)
		groundSizeX = groundSize.x/2;
		groundSizeZ = groundSize.z/2;


		//make the offset of the spawn from the bottom left corner of the map
		this.transform.position = new Vector3 (-groundSizeX,0,-groundSizeZ);

		//generate the spacing based on the map size
		enemySpacing = groundSizeX*3/4;

		generateEnemy ();

	}

	// Update is called once per frame
	void Update () {
		if(gameStarted == true){
			if(transform.childCount == 0){
				StartCoroutine (showHackingPanel());


			}else if(transform.childCount == 1){
				 //turn off the sheild for boss if only it is the only one left

				GameObject enemyBoss1 = GameObject.Find ("EnemyBoss1(Clone)");
				ParticleSystem enemyBoss1Particle = enemyBoss1.GetComponentInChildren<ParticleSystem>() ;
				enemyBoss1Particle.Stop ();
				enemyBoss1.tag = "Enemy";

			}

		}

	}

	//generate enemys in a row and column
	public void generateEnemy(){

		gameStarted = true;


		GameObject enemy = GameObject.Instantiate<GameObject> (enemyBoss1_prefab);

		//size of enemyBoss1_prefab
		Vector3 enemyBoss1Size = enemy.GetComponent<SphereCollider>().bounds.size;

		enemy.transform.parent = this.transform;
		enemy.transform.localPosition = new Vector3 (groundSizeX*1.5f,0,groundSizeZ*1.5f);

		//need to move this enemys y position up a little 
		enemy.transform.localPosition = new Vector3 (enemy.transform.localPosition.x, enemyBoss1Size.y/2 ,enemy.transform.localPosition.z) ;


		GameObject enemyA = GameObject.Instantiate<GameObject> (enemy1_prefab);

		//size of enemy1_prefab
		Vector3 enemy1Size = enemyA.GetComponent<Collider>().bounds.size;

		enemyA.transform.parent = this.transform;
		enemyA.transform.localPosition = new Vector3 (groundSizeX*2-groundSizeX/10,0,0) ;

		//need to move this enemys y position up a little 
		enemyA.transform.localPosition = new Vector3 (enemyA.transform.localPosition.x, enemy1Size.y/2 ,enemyA.transform.localPosition.z);



		GameObject enemyB = GameObject.Instantiate<GameObject> (enemy1_prefab);

		//size of enemy2_prefab
		Vector3 enemy2Size = enemyB.GetComponent<Collider>().bounds.size;

		enemyB.transform.parent = this.transform;
		enemyB.transform.localPosition = new Vector3 (groundSizeX/10,0,0) ;

		//need to move this enemys y position up a little 
		enemyB.transform.localPosition = new Vector3 (enemyB.transform.localPosition.x, enemy2Size.y/2 ,enemyB.transform.localPosition.z);




	}


	IEnumerator showHackingPanel(){


		//wait for 1 second before showing hacking panel and the cursour
		yield return new WaitForSeconds (HACKING_PANEL_WAIT);

		hackingCompletePanel.SetActive(hackingCompletePanel);
		Cursor.visible = true;

	}


}
