using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class InventoryGeneratorScript : MonoBehaviour {

	//get the playerDataScript
	private PlayerDataScript playerDataScript;



	// Use this for initialization
	void Start () {

		playerDataScript = GameObject.Find ("Player Data Manager").GetComponent<PlayerDataScript> ();




	}





}
