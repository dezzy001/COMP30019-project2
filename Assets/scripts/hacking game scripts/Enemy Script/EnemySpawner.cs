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

	// Use this for initialization
	void Start () {
		generateEnemy ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//generate enemys in a row and column
	private void generateEnemy(){

		for(int row = 0; row < enemyRows ;row++){
			for(int col = 0; col < enemyCols ; col++){


					
				int chooseRandEnemy = Random.Range(1,5) ;
				if(row == 1 && col == 1){

					//dont want something spawning at the middle (given row = col = 3)
					continue;

				}else if(row == 2 && col == 2){
					GameObject enemy = GameObject.Instantiate<GameObject> (enemyBoss1_prefab);
					enemy.transform.parent = this.transform;
					enemy.transform.localPosition = new Vector3 (col,0,row) * enemySpacing;

				}else{
					if (chooseRandEnemy < 4) {
						GameObject enemy = GameObject.Instantiate<GameObject> (enemy1_prefab);
						enemy.transform.parent = this.transform;
						enemy.transform.localPosition = new Vector3 (col,0,row) * enemySpacing;

					} else {
						GameObject enemy = GameObject.Instantiate<GameObject> (enemy2_prefab);
						enemy.transform.parent = this.transform;
						enemy.transform.localPosition = new Vector3 (col,0,row) * enemySpacing;

					}	

				}








			}
		}

	}
}
