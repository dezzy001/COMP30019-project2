using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongEnemyProjectile : EnemyProjectileController {



	void OnTriggerEnter(Collider col)
	{

		if (col.gameObject.tag == tagToDamage){
			Debug.Log ("tagged player");
			// Damage object with relevant tag
			HealthManager healthManager = col.gameObject.GetComponent<HealthManager>();
			healthManager.ApplyDamage(damageAmount);
			// Destroy self
			Destroy(this.gameObject);


		}
	}
}
