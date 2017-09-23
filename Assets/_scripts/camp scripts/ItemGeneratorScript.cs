using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

/*Generates all the items in the shop (e.g when you buy an item from shop, changes will be applied to player)*/

public class ItemGeneratorScript : MonoBehaviour {


	//item type
	private string CHIP = "chip";
	private string SKILL = "skill";
	private string SKIN = "skin";


	//array list which stores each item created in the script: will be used to active their information in contents area
	private ArrayList itemContentsArray;
	private List<int> playerItemArray; // to identify which item to add to player


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
		playerItemArray = new List<int> ();

		playerDataScript = GameObject.Find ("Player Data Manager").GetComponent<PlayerDataScript> ();



		/*--------------Item Generation below---------------*/


		//Initialise all items here and add the item to the shop:
		/*chips*/
		Item chip1 = new Item("Chip - Invincibility","+1 invincibility",100,2);
		createNewItem(chipShopGridPanel, chip1, 0, CHIP,"chip 1");


		Item chip2 = new Item("Chip - +1 Player","+1 Player",1000,10);
		createNewItem(chipShopGridPanel,chip2, 1, CHIP ,"chip 2");

		/*skills*/
		Item skill1 = new Item("Skill 1 - Laser","Shoots a laser beam, lots of damage",100000,0);
		createNewItem(skillsShopGridPanel, skill1, 0, SKILL,"skill 1");


		Item skill2 = new Item("Skill 2 - Saber","Throws a light saber from a galaxy far far away...",100000,0);
		createNewItem(skillsShopGridPanel, skill2, 1, SKILL ,"skill 2");

		/*skins*/



		//dont let any item content show
		closeAllItemContent ();
	}
	
	// Update is called once per frame
	void Update () {


	}



	//General Button functions below!


	/*creates a new button with specified text to a specified panel, with a listener attached*/
	void createNewItem(GameObject panel, Item item, int playerItemIndex , string itemType, string buttonText){

		GameObject newButton = Instantiate(selectItemButton_prefab);
		//set the text of the button to a specified one
		newButton.GetComponentInChildren<Text> ().text = buttonText;

		//to prevent scaling, set the second arguement (world scaling argument) to false
		newButton.transform.SetParent(panel.transform,false);

		//create a item content for this item and make item info panel the parent
		GameObject newContent = Instantiate(itemContent_prefab);
		itemContentsArray.Add (newContent);//add to the list of content

		newContent.transform.SetParent (itemPurchasePanel.transform, false);//content will always appear in itemPurchasedPanel


		//initialise item content information here ==== 
		Text[] contentTextList = newContent.GetComponentsInChildren<Text> ();

		/*Components will always be in the following orderorder:
		contentTextList[0] = Item Name
		contentTextList[1] = Information
		contentTextList[2] = cost*/

		contentTextList[0].text = item.itemName;
		contentTextList[1].text = item.itemInformation;
		contentTextList[2].text = "Cost: " + item.itemCost;

		//Buy button implementation here =====


		Button contentBuyButton = newContent.GetComponentInChildren<Button> ();
		contentBuyButton.onClick.AddListener (() => buyItem(playerItemIndex,itemType)); // add a listener which buys the specified item and applies it to the player



		//add a listener which opens the item information when created
		newButton.GetComponent<Button> ().onClick.AddListener(() => openItemContent(newContent));

	}


	public void buyItem(int playerItemIndex, string itemType){

		if(itemType == CHIP){
			playerDataScript.chipsList[playerItemIndex] ++;

		}else if(itemType == SKILL){
			playerDataScript.skillsList[playerItemIndex] ++;

		}else if(itemType == SKIN){
			//playerDataScript.skinsList[playerItemIndex] ++;
			print("Skins have not been implemented yet :(");
		}



		//print ("quantity bought: " + );



		//playerDataScript.chip1++;
		//print ("Item bought: " + playerDataScript.chip1);


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
