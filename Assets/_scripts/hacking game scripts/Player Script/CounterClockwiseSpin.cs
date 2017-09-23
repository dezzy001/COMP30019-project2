using UnityEngine;
using System.Collections;

public class CounterClockwiseSpin : MonoBehaviour {

	public float spinSpeed;

	// Update is called once per frame
	void Update () {
		// Let point light move around the terrain
		this.transform.localRotation *= Quaternion.AngleAxis(spinSpeed * Time.deltaTime, Vector3.down);
	}
}
