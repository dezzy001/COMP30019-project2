using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {
	/*chips, skills and skins are all an item*/


	//item is equipped by user
	public bool hasEquipItem = false;

	//item content
	public string itemName;
	public string itemInformation;
	public int itemCost;

	//how much capacity the item occupies
	public int itemCapacity;

	//generator script variables
	public string buttonName;
	public int itemIndex; // the order it will appear in the shop


	public Item(string itemName,string itemInformation,int itemCost,int itemCapacity, string buttonName, int itemIndex ){//, bool hasEquipItem
		this.itemName = itemName;
		this.itemInformation = itemInformation;
		this.itemCost = itemCost;

		this.itemCapacity = itemCapacity;

		this.buttonName = buttonName;
		this.itemIndex = itemIndex;

		//this.hasEquipItem = hasEquipItem;

	}


}
