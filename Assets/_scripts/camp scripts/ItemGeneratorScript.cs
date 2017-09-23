using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

/*Generates all the items in the shop (e.g when you buy an item from shop, changes will be applied to player)*/

public class ItemGeneratorScript : MonoBehaviour {


	//array list which stores each item created in the script: will be used to active their information in contents area
	private ArrayList itemContentsArray;
	private List<int> contentIndexArray; // to identify which item content to show

	//get the playerDataScript
	private PlayerDataScript playerDataScript;

	//get a button prefab
	public GameObject selectItemButton_prefab;
	public GameObject itemContent_prefab;

	//get the panel to add buttons to
	public GameObject chipShopGridPanel;
	public GameObject skillsShopGridPanel;
	public GameObject skinsShopGridPanel;

	//get the panel to add item contents to
	public GameObject itemPurchasePanel;

	// Use this for initialization
	void Start () {
		itemContentsArray = new ArrayList ();
		contentIndexArray = new List<int> ();

		playerDataScript = GameObject.Find ("Player Data Manager").GetComponent<PlayerDataScript> ();



		/*--------------Item Generation below---------------*/


		//Initialise all items here:
		/*chips*/
		Item chip1 = new Item("Chip - Invincibility","+1 invincibility",100,2);

		Item chip2 = new Item("Chip - +1 Player","+1 Player",1000,10);

		/*skills*/


		/*skins*/



		//Add the item to the shop 
		/*chips*/
		createNewItem(chipShopGridPanel,chip1,"chip 1");
		createNewItem(chipShopGridPanel,chip2,"chip 2");






		//dont let any item content show
		closeAllItemContent ();
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.M)){
			//playerDataScript.chip1 += 1;
			//print ("bought chip 1");

			print (itemContentsArray.Count);
		}



	}



	//General Button functions below!

	/*creates a new button with specified text to a specified panel, with a listener attached*/
	void createNewItem(GameObject panel, Item item, string buttonText){

		GameObject newButton = Instantiate(selectItemButton_prefab);
		//set the text of the button to a specified one
		newButton.GetComponentInChildren<Text> ().text = buttonText;

		//to prevent scaling, set the second arguement (world scaling argument) to false
		newButton.transform.SetParent(panel.transform,false);


		//create a item content for this item and make item info panel the parent
		GameObject newContent = Instantiate(itemContent_prefab);
		itemContentsArray.Add (newContent);//add to the list of content

		newContent.transform.SetParent (itemPurchasePanel.transform, false);//content will always appear in itemPurchasedPanel

		//initialise item content information here
		Text[] contentTextList = newContent.GetComponentsInChildren<Text> ();

		/*Components will always be in the following orderorder:
		contentTextList[0] = Item Name
		contentTextList[1] = Information
		contentTextList[2] = cost*/

		contentTextList[0].text = item.itemName;
		contentTextList[1].text = item.itemInformation;
		contentTextList[2].text = "Cost: " + item.itemCost;


		//add a listener which opens the item information when created
		newButton.GetComponent<Button> ().onClick.AddListener(() => openItemContent(newContent));

	}

	/*Creates the item content gameobject, makes it a child of Item Information panel
	 * , and shows the item informations (information of the items stored using Item class)*/
	void openItemContent(GameObject content){//int contentID
	
		SwitchToItemContent (content);
		//print (content.GetInstanceID()); // debugging purposes!!!!!!!!!!!!!!!!!!!!!!!!--------------------------------------------------------------------

	}


	/*closes all the item info panels*/
	void closeAllItemContent(){

		SwitchToPanel.closeAllPanels (itemContentsArray);


	}

	/*closes all item info panels, and then opens the specified panel*/
	void SwitchToItemContent(GameObject content){

		SwitchToPanel.activatePanel (content,itemContentsArray);

	}



}
