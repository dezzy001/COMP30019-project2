using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public GameObject projectilePrefab;
	//cooldown variables
	public float PROJECTILE_COOLDOWN = 1.5f;// default max cooldown
	private float projectileCooldownCount;// count for the cooldown

	void Start(){
		projectileCooldownCount = PROJECTILE_COOLDOWN; //init cooldown count
	}

	// Update is called once per frame
	void Update () {
		HealthManager healthManager = this.gameObject.GetComponent<HealthManager>();
		MeshRenderer renderer = this.gameObject.GetComponent<MeshRenderer>();

		// Make enemy material darker based on its health
		renderer.material.color = Color.red * ((float)healthManager.GetHealth() / 100.0f);

		//should put this in a method later ...
		if (projectileCooldownCount <= 0){
			
			GameObject projectile = Instantiate<GameObject>(projectilePrefab);

			//projectile will have the same position as player
			projectile.transform.position = this.gameObject.transform.position;

			//make projectile face the same direction as player
			Vector3 playerDir = new Vector3 (0.0f, Random.Range(0,360),0.0f);
			projectile.transform.eulerAngles = playerDir ;


			//reset cooldown after you shoot 
			projectileCooldownCount = PROJECTILE_COOLDOWN;

		}

		if(projectileCooldownCount>0){
			projectileCooldownCount -= Time.deltaTime;
		}
	}
}
