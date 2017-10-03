	using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2old : MonoBehaviour {


	//when game complete show the hacking complete panel
	public GameObject hackingCompletePanel;
	private bool gameStarted = false;
	private float HACKING_PANEL_WAIT = 0.3f;


	//number of enemys 
	public int enemyRows = 3;
	public int enemyCols = 3;
	public float enemySpacing = 3.5f;


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
	void Awake () {

		hackingCompletePanel.SetActive(false);

		//ground boundaries
		ground = GameObject.Find("Ground");
		Renderer groundSizeRenderer = ground.GetComponent<Renderer>();
		Vector3 groundSize = groundSizeRenderer.bounds.size;

		//divided by 2 for maths purposes (origin of ground is at 0,0 and largeset x is groundSize.x/2)
		groundSizeX = groundSize.x/2;
		groundSizeZ = groundSize.z/2;

		//make the offset of the spawn from the bottom left corner of the map
		this.transform.position = new Vector3 (-groundSizeX + groundSizeX/5,0,-groundSizeZ + groundSizeX/5);

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

				GameObject enemyBoss1BodyPart = GameObject.Find ("EnemyBoss1(Clone)/EnemyBoss1 BodyPart");
				ParticleSystem enemyBoss1Particle = enemyBoss1BodyPart.GetComponentInChildren<ParticleSystem>() ;
				enemyBoss1Particle.Stop ();
				GameObject.Find ("EnemyBoss1(Clone)").tag = "Enemy";

			}

		}

	}

	//generate enemys in a row and column
	public void generateEnemy(){

		gameStarted = true;

		//get the xyz, in each if statement, i.e for each enemy , so we can make it spawn on the ground

		for(int row = 0; row < enemyRows ;row++){
			for(int col = 0; col < enemyCols ; col++){



				int chooseRandEnemy = Random.Range(1,5) ;
				if(row == 1 && col == 1){

					//dont want something spawning at the middle (given row = col = 3)
					continue;

				}else if(row == 2 && col == 2){
					GameObject enemy = GameObject.Instantiate<GameObject> (enemyBoss1_prefab);

					//size of enemyBoss1_prefab
					Vector3 enemyBoss1Size = enemy.GetComponent<Collider>().bounds.size;

					enemy.transform.parent = this.transform;
					enemy.transform.localPosition = new Vector3 (col,0,row) * enemySpacing;

					//need to move this enemys y position up a little 
					enemy.transform.localPosition = new Vector3 (enemy.transform.localPosition.x, enemyBoss1Size.y/2 ,enemy.transform.localPosition.z) ;

				}else{
					if (chooseRandEnemy < 4) {
						GameObject enemy = GameObject.Instantiate<GameObject> (enemy1_prefab);

						//size of enemy1_prefab
						Vector3 enemy1Size = enemy.GetComponent<Collider>().bounds.size;

						enemy.transform.parent = this.transform;
						enemy.transform.localPosition = new Vector3 (col,0,row) * enemySpacing;

						//need to move this enemys y position up a little 
						enemy.transform.localPosition = new Vector3 (enemy.transform.localPosition.x, enemy1Size.y/2 ,enemy.transform.localPosition.z);


					} else {
						GameObject enemy = GameObject.Instantiate<GameObject> (enemy2_prefab);

						//size of enemy2_prefab
						Vector3 enemy2Size = enemy.GetComponent<Collider>().bounds.size;

						enemy.transform.parent = this.transform;
						enemy.transform.localPosition = new Vector3 (col,0,row) * enemySpacing;

						//need to move this enemys y position up a little 
						enemy.transform.localPosition = new Vector3 (enemy.transform.localPosition.x, enemy2Size.y/2 ,enemy.transform.localPosition.z);
					}	

				}

			}
		}

	}


	IEnumerator showHackingPanel(){


		//wait for 1 second before showing hacking panel and the cursour
		yield return new WaitForSeconds (HACKING_PANEL_WAIT);

		hackingCompletePanel.SetActive(hackingCompletePanel);
		Cursor.visible = true;

	}


}
