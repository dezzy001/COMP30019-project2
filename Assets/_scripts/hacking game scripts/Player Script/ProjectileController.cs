using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProjectileController : MonoBehaviour {

	public Vector3 velocity = new Vector3(40,0,0);
	public int damageAmount = 25; // default player projectile damage

    public string tagToDamage = "Enemy";
	public string tagUntouchableEnemys = "EnemyUntouchable";

	void Start(){
		/*
		MeshRenderer renderer = this.gameObject.GetComponent<MeshRenderer>();
		renderer.material.color = Color.yellow;
		*/

	}

    // Update is called once per frame
    void Update () {
        this.transform.Translate(velocity * Time.deltaTime);


	}

    // Handle collisions
    void OnTriggerEnter(Collider col){

        if (col.gameObject.tag == tagToDamage){
			
			// Damage object with relevant tag
			HealthManager healthManager = col.gameObject.GetComponent<HealthManager>();
			healthManager.ApplyDamage(damageAmount);
            
			// Destroy self
            Destroy(this.gameObject);

        }

		//cannot damage these enemys
		if(col.gameObject.tag == tagUntouchableEnemys){

			// Destroy self
			Destroy(this.gameObject);

		}

    }
}
