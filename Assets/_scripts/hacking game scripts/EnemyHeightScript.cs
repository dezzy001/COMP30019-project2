using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*
This class finds the height from the enemys origin to the ground, so enemy can be appropriately spawned at ground level

*/


public class EnemyHeightScript : MonoBehaviour {

	//gets the height from ground to origin, This method assumes that the y origin is half the heigh of the object

	public static float getEnemyHeight(GameObject enemy){
		
		Vector3 enemySize = enemy.GetComponent<Collider>().bounds.size;

		return enemySize.y/2;


	}
}
