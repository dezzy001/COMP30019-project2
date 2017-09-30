using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {


	//get all the item information from item generator script
	public ItemGeneratorScript itemGeneratorScript;

	public Item chip1;
	public Item chip2;
	public Item skill1;
	public Item skill2;


	// Use this for initialization
	void Start () {

		chip1 = itemGeneratorScript.chip1;
		chip2 = itemGeneratorScript.chip2;

		skill1 = itemGeneratorScript.skill1;
		skill2 = itemGeneratorScript.skill2;

		print (chip1.itemName + ", "+chip1.itemCost);


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
