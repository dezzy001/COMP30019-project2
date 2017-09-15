using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakEnemyProjectile : EnemyProjectileController {


	//public int damageAmount = 34;


	void OnTriggerEnter(Collider col)
	{

		if (col.gameObject.tag == tagToDamage){
			
			// Damage object with relevant tag
			HealthManager healthManager = col.gameObject.GetComponent<HealthManager>();
			healthManager.ApplyDamage(damageAmount);
			// Destroy self
			Destroy(this.gameObject);


		}
	}

}
