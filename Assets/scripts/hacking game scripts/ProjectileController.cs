using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProjectileController : MonoBehaviour {

    public Vector3 velocity;



    public string tagToDamage;


	void Start(){
		MeshRenderer renderer = this.gameObject.GetComponent<MeshRenderer>();
		renderer.material.color = Color.yellow;

	}

    // Update is called once per frame
    void Update () {
        this.transform.Translate(velocity * Time.deltaTime);



	}

    // Handle collisions
    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == tagToDamage){

            // Destroy self
            Destroy(this.gameObject);

			//Destory Enemy
			Destroy(col.gameObject);

        }
    }
}
