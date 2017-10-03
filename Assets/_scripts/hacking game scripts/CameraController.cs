using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*A camera script which follows the player (similar to roll a ball camera script)
*/
public class CameraController : MonoBehaviour {



	public GameObject player;
	private float playerZposFromOrigin;
	public float centerOffset = 5.0f;

	private Vector3 offset;

	//public float offset = 15.0f;

	// Use this for initialization
	void Start () {


		player = GameObject.Find ("Player");

		offset = transform.position - player.transform.position;

		//player z distance from the centre of the map
		playerZposFromOrigin = player.transform.position.z;

		//player.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2,Screen.height/2, Camera.main.nearClipPlane));


	}
	
	// Update is called once per frame
	void LateUpdate () {
		if(player != null){

			//transform.position = new Vector3(player.transform.position.x,player.transform.position.y + offset,player.transform.position.z) ;

			transform.position = new Vector3(player.transform.position.x,player.transform.position.y,player.transform.position.z + playerZposFromOrigin + centerOffset) + offset;

			//transform.position = player.transform.position + offset;
			//this.transform.position = Vector3.Lerp(transform.position,player.transform.position + offset, player.GetComponent<PlayerController>().speed * Time.deltaTime);
		}

	}
}
