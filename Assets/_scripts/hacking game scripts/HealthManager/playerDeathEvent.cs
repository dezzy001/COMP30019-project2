using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDeathEvent : MonoBehaviour {

	public GameObject player;
	//public GameObject playerDeadPanel;

	public static bool playerDead = false;

	// Use this for initialization
	void Start () {
		playerDead = false;
		//print (playerDead);
		//playerDeadPanel.SetActive (false);
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void openPlayerDeadPanel(){

		//Destroy (player.gameObject);

		//turn off all functionality and rendering of the player
		GameObject.Find("Player/Player Spawn Particle System/playerfront").SetActive(false);
		GameObject.Find("Player/Player Spawn Particle System/playercircle").SetActive(false);
		player.GetComponent<PlayerController> ().allowKeypressMovement = false;
		player.GetComponent<PlayerController> ().allowMouseLeftClick = false;
		player.GetComponent<PlayerController> ().allowMouseRotation = false;

		playerDead = true;
		//playerDeadPanel.SetActive (true);

	}

}
