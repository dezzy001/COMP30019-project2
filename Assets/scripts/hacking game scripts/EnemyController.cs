using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        MeshRenderer renderer = this.gameObject.GetComponent<MeshRenderer>();

        // Make enemy material darker based on its health
        renderer.material.color = Color.black;
	}
}
