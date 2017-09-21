using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoUI : MonoBehaviour {

	private bool onOffPlayerInfo = true;

	//drag and drops
	public PlayerDataScript playerData;
	public GameObject playerInfoPanel;

	public Text maps;
	public Text gold;
	public Text itemCount;

	// Use this for initialization
	void Start () {
		playerInfoPanel.SetActive (onOffPlayerInfo);

		playerData = GameObject.Find ("Player Data Manager").GetComponent<PlayerDataScript> ();

	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.I)){
			
			onOffPlayerInfo = !onOffPlayerInfo;
			playerInfoPanel.SetActive (onOffPlayerInfo);
		}

		maps.text = "Maps Completed: " + playerData.mapsCompleted;
		gold.text = "Gold: " + playerData.currencyAmount;


		int countForItems = 0;


		foreach(bool hasChip in playerData.chipsList){
			if(hasChip == true){
				countForItems++;
			}
		}

		itemCount.text = "chip Count: " + countForItems;

	}



}
