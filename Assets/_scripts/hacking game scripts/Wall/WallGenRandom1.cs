using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenRandom1 : WallGeneratorScript {


	void Start(){
		generateRandomWalls (wallGrey_prefab,wallWhite_prefab,enemyRows,enemyCols, enemySpacing,this.gameObject);
	}


	//generate walls in a row and column
	public void generateRandomWalls(GameObject wall_Prefab1, GameObject wall_Prefab2, int enemyRows, 
		int enemyCols, float enemySpacing, GameObject thisGameObject){

		//get the xyz, in each if statement, i.e for each wall , so we can make it spawn on the ground

		for(int row = 0; row < enemyRows ;row++){
			int whiteWallCount = 0;
			for(int col = 0; col < enemyCols ; col++){

				int chooseRandWall = Random.Range(1,3) ;

				GameObject wall;
				if(chooseRandWall == 1 || whiteWallCount > 1  ){
					wall = GameObject.Instantiate<GameObject> (wall_Prefab1);//grey

				}else{
					wall = GameObject.Instantiate<GameObject> (wall_Prefab2);//white
					whiteWallCount++;
				}


				//size of enemyBoss1_prefab
				Vector3 wallSize = wall.GetComponent<Collider>().bounds.size;

				wall.transform.parent = thisGameObject.transform;
				wall.transform.localPosition = new Vector3 (col,0,row) * enemySpacing;

				//need to move this enemys y position up a little 
				wall.transform.localPosition = new Vector3 (wall.transform.localPosition.x, wallSize.y/2 ,wall.transform.localPosition.z) ;

			}



		}
	}


}
