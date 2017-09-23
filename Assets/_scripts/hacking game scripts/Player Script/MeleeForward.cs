using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeForward : MonoBehaviour {

	public Vector3 velocity;
	public float forward_time = 1.0f;
	public float backward_time = 1.0f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (forward_time >= 0.0f) {
			this.transform.Translate (velocity * Time.deltaTime);
			forward_time -= Time.deltaTime;
		}

		if (forward_time < 0.0f && backward_time >= 0.0f) {
			// this.transform.Translate (-velocity * Time.deltaTime);
			backward_time -= Time.deltaTime;
		}

		if (forward_time < 0.0f && backward_time < 0.0f) {
			Destroy (this.gameObject);
		}
	}

}
