using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGoldCount : MonoBehaviour {


	public Text goldAmountText;

	public PlayerDataScript playerdataScript;

	// Use this for initialization
	void Start () {
		playerdataScript = GameObject.Find ("Player Data Manager").GetComponent<PlayerDataScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		goldAmountText.text = playerdataScript.currencyAmount.ToString();
	}
}
