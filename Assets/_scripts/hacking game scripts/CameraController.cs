using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*A camera script which follows the player (similar to roll a ball camera script)
*/
public class CameraController : MonoBehaviour {



	public GameObject player;

	private Vector3 offset;

	// Use this for initialization
	void Start () {

		offset = transform.position - player.transform.position;



	}
	
	// Update is called once per frame
	void LateUpdate () {
		if(player != null){
			transform.position = player.transform.position + offset;
			//this.transform.position = Vector3.Lerp(transform.position,player.transform.position + offset, player.GetComponent<PlayerController>().speed * Time.deltaTime);
		}

	}
}
