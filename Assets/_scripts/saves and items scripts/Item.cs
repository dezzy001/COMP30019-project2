using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {
	/*chips, skills and skins are all an item*/


	//item content
	public string itemName;
	public string itemInformation;
	public int itemCost;

	//how much capacity the item occupies
	public int itemCapacity;

	public Item(string itemName,string itemInformation,int itemCost,int itemCapacity){
		this.itemName = itemName;
		this.itemInformation = itemInformation;
		this.itemCost = itemCost;

		this.itemCapacity = itemCapacity;

	}


}
