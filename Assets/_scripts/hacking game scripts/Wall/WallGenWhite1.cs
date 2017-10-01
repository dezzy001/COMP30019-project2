using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenWhite1 : WallGeneratorScript {

	void Start(){
		generateWalls (wallWhite_prefab,enemyRows,enemyCols, enemySpacing,this.gameObject);
	}
}
