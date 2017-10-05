﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class InventoryGeneratorScript : MonoBehaviour {


	//item type
	private string CHIP = "chip";
	private string SKILL = "skill";
	private string SKIN = "skin";

	//array list which stores each inventory panel created in the script: will be used to active their information in contents area
	private ArrayList inventoryContentsArray;


	//get the playerDataScript
	private PlayerDataScript playerDataScript;

	//get a button prefab
	public GameObject selectItemButton_prefab;
	public GameObject itemContent_prefab;

	//get the panel to add buttons to
	public GameObject chipInventoryGridPanel;
	public GameObject skillsInventoryGridPanel;
	public GameObject skinsInventoryGridPanel;

	//popup notice panel
	public GameObject noCapacityPopUpPanel;
	public float POPUP_WAIT_TIME = 1.2f;

	//get the panel to add item contents to
	public GameObject inventoryInfoPanel;

	//get the button which opens the whole shop
	public Button inventoryButton;


	//get item info from ItemData
	public ItemData itemData;

	/*Items Here*/
	public Item chip1;
	public Item chip2;
	public Item chip3;
	public Item chip4;

	public Item skill1;
	public Item skill2;

	public Item skin1;



	//chip capacity text
	public Text capacityText;
	private int currentPlayerCapacity;

	//add sound to all the initialised buttons
	public ClickSound clickSound;


	void Start () {
		inventoryContentsArray = new ArrayList ();

		//find the persisted data
		playerDataScript = GameObject.Find ("Player Data Manager").GetComponent<PlayerDataScript> ();
		itemData = GameObject.Find ("ItemData").GetComponent<ItemData> ();

		//calculate the current player capcity
		currentPlayerCapacity = 0;


		/*--------------Item Generation below---------------*/


		//Initialise all items here and add the item to the shop:
		/*chips*/
		//Initialise all items here and add the item to the shop:
		/*chips*/
		chip1 = itemData.chip1;
		addInventory(chipInventoryGridPanel, chip1, 0, CHIP,"chip 1");
		chip2 = itemData.chip2;
		addInventory(chipInventoryGridPanel,chip2, 1, CHIP ,"chip 2");
		chip3 = itemData.chip3;
		addInventory(chipInventoryGridPanel, chip3, 2, CHIP,"chip 3");
		chip4 = itemData.chip4;
		addInventory(chipInventoryGridPanel,chip4, 3, CHIP ,"chip 4");

		/*skills*/
		skill1 = itemData.skill1;
		addInventory(skillsInventoryGridPanel, skill1, 0, SKILL,"skill 1");
		skill2 = itemData.skill2;
		addInventory(skillsInventoryGridPanel, skill2, 1, SKILL ,"skill 2");

		/*skins*/
		skin1 = itemData.skin1;
		addInventory (skinsInventoryGridPanel, skin1, 0, SKIN, "skin 1");


		//dont let any item content show when the shop button is pressed
		inventoryButton.onClick.AddListener(()=>closeContent());

	}

	void closeContent(){
		closeAllItemContent ();
	}

	//General Button functions below!

	//add uten to inventory if the player has the item
	public void addInventory(GameObject panel, Item item, int playerItemIndex , string itemType, string buttonText){
		//only create new inventory if player has the item
		if(itemType == CHIP){
			if(playerDataScript.chipsList[playerItemIndex] > 0){
				createNewInventory (panel, item, playerItemIndex, itemType, buttonText);
			}


		}else if(itemType == SKILL){
			if(playerDataScript.skillsList[playerItemIndex] > 0){
				createNewInventory (panel, item, playerItemIndex, itemType, buttonText);
			}
		}else if(itemType == SKIN){

			if(playerDataScript.skinsList[playerItemIndex] > 0){
				createNewInventory (panel, item, playerItemIndex, itemType, buttonText);
			}
		}
	}

	/*creates a new button with specified text to a specified panel, with a listener attached*/
	public void createNewInventory(GameObject panel, Item item, int playerItemIndex , string itemType, string buttonText){




		GameObject newButton = Instantiate(selectItemButton_prefab);
		//set the text of the button to a specified one
		newButton.GetComponentInChildren<Text> ().text = buttonText;

		//to prevent scaling, set the second arguement (world scaling argument) to false
		newButton.transform.SetParent(panel.transform,false);

		//create a item content for this item and make item info panel the parent
		GameObject newContent = Instantiate(itemContent_prefab);
		inventoryContentsArray.Add (newContent);//add to the list of content

		newContent.transform.SetParent (inventoryInfoPanel.transform, false);//content will always appear in itemPurchasedPanel


		//initialise item content information here ==== 
		Text[] contentTextList = newContent.GetComponentsInChildren<Text> ();

		/*Components will always be in the following orderorder:
		contentTextList[0] = Item Name
		contentTextList[1] = Information
		contentTextList[3] = Capacity*/

		contentTextList[0].text = item.itemName;
		contentTextList[1].text = item.itemInformation;
		contentTextList[2].text = "Capacity: " + item.itemCapacity;


		// button which opens item content here =====
		//add a listener which opens the item information when created
		Button newButtonComponent = newButton.GetComponent<Button> ();
		newButtonComponent.onClick.AddListener(() => openItemContent(newContent));


		//Buy button implementation here =====
		Button contentBuyButton = newContent.GetComponentInChildren<Button> ();

		contentBuyButton.onClick.AddListener (() => equipItem(playerItemIndex,itemType, contentBuyButton, item, newButtonComponent, buttonText)); // add a listener which buys the specified item and applies it to the player

		//show the equip button text as equip or unequip before the scene loads. also calculates chip capacity (basically loads the state of the inventory beforehand)
		if(itemType == CHIP){

			if(playerDataScript.chipsList[playerItemIndex] > 0){
				
				if (playerDataScript.hasEquipchips [playerItemIndex] == true) {
					contentBuyButton.GetComponentInChildren<Text> ().text = "Unequip";
					currentPlayerCapacity += item.itemCapacity;

					newButtonComponent.image.color = new Color(0.6f,0.6f,0.6f,0.6f);
					newButtonComponent.GetComponentInChildren<Text> ().text = buttonText + " (Equipped)";

				} else {
					contentBuyButton.GetComponentInChildren<Text> ().text = "Equip";
				}

			}


		}else if(itemType == SKILL){
			if(playerDataScript.skillsList[playerItemIndex] > 0){
				if(playerDataScript.hasEquipskills[playerItemIndex] == true){
					contentBuyButton.GetComponentInChildren<Text> ().text = "Unequip";
					currentPlayerCapacity += item.itemCapacity;

					newButtonComponent.image.color = new Color(0.6f,0.6f,0.6f,0.6f);
					newButtonComponent.GetComponentInChildren<Text> ().text = buttonText + " (Equipped)";
				} else {
					contentBuyButton.GetComponentInChildren<Text> ().text = "Equip";
				}

			}
		}else if(itemType == SKIN){

			if(playerDataScript.skinsList[playerItemIndex] > 0){
				if(playerDataScript.hasEquipSkins[playerItemIndex] == true){
					
					contentBuyButton.GetComponentInChildren<Text> ().text = "Unequip";
					currentPlayerCapacity += item.itemCapacity;

					newButtonComponent.image.color = new Color(0.6f,0.6f,0.6f,0.6f);
					newButtonComponent.GetComponentInChildren<Text> ().text = buttonText + " (Equipped)";
				} else {
					contentBuyButton.GetComponentInChildren<Text> ().text = "Equip";
				}
			}
		}





	}


	//equips the item when you press equip and unequips if u press unequip. button text also changes. also calculates chip capacity 
	public void equipItem(int playerItemIndex, string itemType, Button contentBuyButton, Item item, Button newButtonComponent, string buttonText){

		clickSound.PlaySound ();

		if(itemType == CHIP){
			if(playerDataScript.chipsList[playerItemIndex] > 0){

				if (playerDataScript.hasEquipchips [playerItemIndex] == true) {//want to UNequip
					
					currentPlayerCapacity -= item.itemCapacity;//decrease item capacity

					playerDataScript.hasEquipchips [playerItemIndex] = false;
					contentBuyButton.GetComponentInChildren<Text> ().text = "Equip";

					newButtonComponent.image.color = Color.white;
					newButtonComponent.GetComponentInChildren<Text> ().text = buttonText;



				} else { // want to equip

					//cannot equip if adding on the item capcity to current capcity exceeds player capacity
					if(item.itemCapacity + currentPlayerCapacity >  playerDataScript.itemCapacity){
						//print ("capacity exceeds...");
						//show a message to the user saying that cannot equip since capcity exceeds player capacity
						openPopUp(noCapacityPopUpPanel);

					}else{
						currentPlayerCapacity += item.itemCapacity;
						playerDataScript.hasEquipchips [playerItemIndex] = true;
						contentBuyButton.GetComponentInChildren<Text> ().text = "Unequip";

						newButtonComponent.image.color = new Color(0.6f,0.6f,0.6f,0.6f);
						newButtonComponent.GetComponentInChildren<Text> ().text = buttonText + " (Equipped)";

					}
				}

			}


		}else if(itemType == SKILL){
			
			if(playerDataScript.skillsList[playerItemIndex] > 0){
				if(playerDataScript.hasEquipskills[playerItemIndex] == true){
					
					currentPlayerCapacity -= item.itemCapacity;//decrease item capacity

					playerDataScript.hasEquipskills [playerItemIndex] = false;
					contentBuyButton.GetComponentInChildren<Text> ().text = "Equip";

					newButtonComponent.image.color = Color.white;
					newButtonComponent.GetComponentInChildren<Text> ().text = buttonText;
				} else {
					//cannot equip if adding on the item capcity to current capcity exceeds player capacity
					if (item.itemCapacity + currentPlayerCapacity > playerDataScript.itemCapacity) {
						//print ("capacity exceeds...");
						//show a message to the user saying that cannot equip since capcity exceeds player capacity
						openPopUp(noCapacityPopUpPanel);

					} else {
						currentPlayerCapacity += item.itemCapacity;
						playerDataScript.hasEquipskills [playerItemIndex] = true;
						contentBuyButton.GetComponentInChildren<Text> ().text = "Unequip";

						newButtonComponent.image.color = new Color(0.6f,0.6f,0.6f,0.6f);
						newButtonComponent.GetComponentInChildren<Text> ().text = buttonText + " (Equipped)";
					}
				}

			}
		}else if(itemType == SKIN){

			if(playerDataScript.skinsList[playerItemIndex] > 0){
				
				if(playerDataScript.hasEquipSkins[playerItemIndex] == true){
					
					currentPlayerCapacity -= item.itemCapacity;//decrease item capacity

					playerDataScript.hasEquipSkins [playerItemIndex] = false;
					contentBuyButton.GetComponentInChildren<Text> ().text = "Equip";

					newButtonComponent.image.color = Color.white;
					newButtonComponent.GetComponentInChildren<Text> ().text = buttonText;
				} else {
					//cannot equip if adding on the item capcity to current capcity exceeds player capacity
					if (item.itemCapacity + currentPlayerCapacity > playerDataScript.itemCapacity) {
						//print ("capacity exceeds...");
						//show a message to the user saying that cannot equip since capcity exceeds player capacity
						openPopUp(noCapacityPopUpPanel);
					} else {
						currentPlayerCapacity += item.itemCapacity;
						playerDataScript.hasEquipSkins [playerItemIndex] = true;
						contentBuyButton.GetComponentInChildren<Text> ().text = "Unequip";

						newButtonComponent.image.color = new Color(0.6f,0.6f,0.6f,0.6f);
						newButtonComponent.GetComponentInChildren<Text> ().text = buttonText + " (Equipped)";
					}
				}
			}
		}

	}
		



	/*Creates the item content gameobject, makes it a child of Item Information panel
	 , and shows the item informations (information of the items stored using Item class)*/
	void openItemContent(GameObject content){//int contentID

		clickSound.PlaySound ();
		SwitchToItemContent (content);
	}


	/*closes all the item info panels*/
	void closeAllItemContent(){

		SwitchToPanel.closeAllPanels (inventoryContentsArray);


	}

	/*closes all item info panels, and then opens the specified panel*/
	void SwitchToItemContent(GameObject content){

		SwitchToPanel.activatePanel (content,inventoryContentsArray);

	}


	//open a pop up for a certain amount of time then close it
	public void openPopUp(GameObject popUpPanel){
		StartCoroutine(openPopUpTime (popUpPanel));
	}

	public IEnumerator openPopUpTime(GameObject popUpPanel){
		popUpPanel.SetActive (true);
		yield return new WaitForSeconds (POPUP_WAIT_TIME);
		popUpPanel.SetActive (false);
	}

		
	void Update(){

		capacityText.text = currentPlayerCapacity + "/" + playerDataScript.itemCapacity.ToString() ;

	
	}







}
