using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDeadScript : MonoBehaviour {

	public GameObject playerDeadPanel;



	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		
		if (playerDeathEvent.playerDead == true) {
			//print (playerDeathEvent.playerDead);
			playerDeadPanel.SetActive (true);
		}

	}
}
