using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {


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

	// Use this for initialization
	void Start () {

	
		generateEnemy ();

	}
	
	// Update is called once per frame
	void Update () {
		//can dynamically spawn enemys here
	}

	//generate enemys in a row and column
	private void generateEnemy(){

		//get the xyz for each enemy , so we can make it spawn on the ground

		/*
		//get the xyz values of this object
		//Renderer enemy1Rend = enemy1_prefab.GetComponent<Renderer>();
		Vector3 enemy1Size = Vector3.zero; //enemy1Rend.bounds.size;

		//get the xyz values of this object
		Renderer enemy2Rend = enemy2_prefab.GetComponent<Renderer>();

		Vector3 enemy2Size = enemy2Rend.bounds.size;


		//get the xyz values of this object
		Renderer enemyBoss1Rend = enemyBoss1_prefab.GetComponent<Renderer>();
		Vector3 enemyBoss1Size = enemyBoss1Rend.bounds.size;
		*/


		for(int row = 0; row < enemyRows ;row++){
			for(int col = 0; col < enemyCols ; col++){


					
				int chooseRandEnemy = Random.Range(1,5) ;
				if(row == 1 && col == 1){

					//dont want something spawning at the middle (given row = col = 3)
					continue;

				}else if(row == 2 && col == 2){
					GameObject enemy = GameObject.Instantiate<GameObject> (enemyBoss1_prefab);

					//size of enemyBoss1_prefab
					Vector3 enemyBoss1Size = enemy.GetComponent<SphereCollider>().bounds.size;

					enemy.transform.parent = this.transform;
					enemy.transform.localPosition = new Vector3 (col,0,row) * enemySpacing;

					//need to move this enemys y position up a little 
					enemy.transform.localPosition = new Vector3 (enemy.transform.localPosition.x, enemyBoss1Size.y/2 ,enemy.transform.localPosition.y) ;

				}else{
					if (chooseRandEnemy < 4) {
						GameObject enemy = GameObject.Instantiate<GameObject> (enemy1_prefab);

						//size of enemy1_prefab
						Vector3 enemy1Size = enemy.GetComponent<BoxCollider>().bounds.size;
						Debug.Log (enemy1Size);

						enemy.transform.parent = this.transform;
						enemy.transform.localPosition = new Vector3 (col,0,row) * enemySpacing;

						//need to move this enemys y position up a little 
						enemy.transform.localPosition = new Vector3 (enemy.transform.localPosition.x, enemy1Size.y/2 ,enemy.transform.localPosition.y);


					} else {
						GameObject enemy = GameObject.Instantiate<GameObject> (enemy2_prefab);

						//size of enemy2_prefab
						Vector3 enemy2Size = enemy.GetComponent<CapsuleCollider>().bounds.size;

						enemy.transform.parent = this.transform;
						enemy.transform.localPosition = new Vector3 (col,0,row) * enemySpacing;


						//need to move this enemys y position up a little 
						enemy.transform.localPosition = new Vector3 (enemy.transform.localPosition.x, enemy2Size.y/2 ,enemy.transform.localPosition.y);
					}	

				}
					
			}
		}

	}
}
