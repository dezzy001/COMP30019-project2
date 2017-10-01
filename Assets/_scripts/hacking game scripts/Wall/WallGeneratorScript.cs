using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGeneratorScript : MonoBehaviour {


	//number of enemys 
	public int enemyRows = 2;
	public int enemyCols = 2;
	public float enemySpacing = 2.3f;


	//enemy prefabs
	public GameObject wallGrey_prefab;
	public GameObject wallWhite_prefab;


	//enemy sizes
	private Vector3 wallGreySize;
	private Vector3 wallWhiteSize;

	/*
	//ground game object - need the boundaries of the map
	public GameObject ground;
	float groundSizeX;
	float groundSizeZ; 
	*/

	// Use this for initialization
	void Start () {

		/*
		//ground boundaries
		ground = GameObject.Find("Ground");
		Renderer groundSizeRenderer = ground.GetComponent<Renderer>();
		Vector3 groundSize = groundSizeRenderer.bounds.size;

		//divided by 2 for maths purposes (origin of ground is at 0,0 and largeset x is groundSize.x/2)
		groundSizeX = groundSize.x/2;
		groundSizeZ = groundSize.z/2;

		*/

	}


	//generate walls in a row and column - only one type of all
	public void generateWalls(GameObject wall_Prefab, int enemyRows, int enemyCols, float enemySpacing, GameObject thisGameObject){

		//get the xyz, in each if statement, i.e for each wall , so we can make it spawn on the ground

		for(int row = 0; row < enemyRows ;row++){
			for(int col = 0; col < enemyCols ; col++){
				
				GameObject wall = GameObject.Instantiate<GameObject> (wall_Prefab);

				//size of enemyBoss1_prefab
				Vector3 wallSize = wall.GetComponent<Collider>().bounds.size;

				wall.transform.parent = thisGameObject.transform;
				wall.transform.localPosition = new Vector3 (col,0,row) * enemySpacing;

				//need to move this enemys y position up a little 
				wall.transform.localPosition = new Vector3 (wall.transform.localPosition.x, wallSize.y/2 ,wall.transform.localPosition.z) ;

		}



		}
	}


	//generate walls in a row and column
	public void generateRandomWalls(GameObject wall_Prefab1, GameObject wall_Prefab2, int enemyRows, 
		int enemyCols, float enemySpacing, GameObject thisGameObject){

		//get the xyz, in each if statement, i.e for each wall , so we can make it spawn on the ground

		for(int row = 0; row < enemyRows ;row++){
			for(int col = 0; col < enemyCols ; col++){

				int chooseRandWall = Random.Range(1,3) ;

				GameObject wall;
				if(chooseRandWall == 1){
					wall = GameObject.Instantiate<GameObject> (wall_Prefab1);
				}else{
					wall = GameObject.Instantiate<GameObject> (wall_Prefab2);
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
