using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenGrey1 : WallGeneratorScript {

	void Start(){
		generateWalls (wallGrey_prefab,enemyRows,enemyCols, enemySpacing,this.gameObject);
	}
}
