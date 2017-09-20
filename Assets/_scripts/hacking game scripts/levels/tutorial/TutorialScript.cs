using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour {

	//panels
	public GameObject tutorial1;
	public GameObject tutorial2;
	public GameObject tutorial3;
	public GameObject tutorial3a;

	public GameObject tutorial4;
	public GameObject tutorial5;
	public GameObject tutorial5a;

	public GameObject tutorial6;

	//misc variables + constants
	private bool finnishedTutorialCubes = false;// turns true when you finish the cube tutorial

	// true when tutorial panel is active


	private bool moveHereExists = false;

	private bool firstTime = true;//first time clicking a panel, disable if it isnt
	private bool spawnCubeOnce = true;//ensure tutorial only spawns cube tutorial only once
	private bool spawnMoveToOnce = true;//ensure tutorial only spawns move to tutorial only once

	//constants
	public float SPAWN_CUBES_WAIT = 1.5f;
	public float DELAY_B4_NEXT_TUT = 0.35f;


	//prefabs
	public GameObject tutorialCube_prefab;
	public GameObject moveHere_prefab;

	//player controller script
	private PlayerController player;
	private string playerTag = "Player";


	//instantiated prefabs 
	private GameObject tutorialCubes;
	private GameObject moveHere;

	//public SwitchToPanel switchToPanelScript;

	private ArrayList allTutorialPanels = new ArrayList();

	// Use this for initialization
	void Start () {
		allTutorialPanels.Add (tutorial1);
		allTutorialPanels.Add (tutorial2);
		allTutorialPanels.Add (tutorial3);
		allTutorialPanels.Add (tutorial3a);
		allTutorialPanels.Add (tutorial4);
		allTutorialPanels.Add (tutorial5);
		allTutorialPanels.Add (tutorial5a);
		allTutorialPanels.Add (tutorial6);

		clickToPanel (tutorial1);

		//get the player, used for limiting player controlls during tutorial
		player = GameObject.Find(playerTag).GetComponent<PlayerController> ();
		player.allowKeypressMovement = false;
		player.allowMouseLeftClick = true;
		player.allowMouseRotation = false;

		//want to deactive the pause function at this stage of the tutorial
		PauseScript pauseScript = GameObject.Find("SceneManagement Script").GetComponent<PauseScript>();
		pauseScript.allowPauseKey = false;

	}
	
	// Update is called once per frame
	void Update () {


		//tutorial 3--------------------------
		//allow mouse rotation at third tutorial panel
		if(tutorial3.activeSelf == true){
			player.allowMouseRotation = true;
		}


			

	}
		


	/*static function which allows a panel to be moved vertically by a speed, to a specified height*/
	public static void movePanelToBottom(GameObject panel, float speed, float stopHeight){

		if(panel.transform.position.y > stopHeight){
			panel.transform.position = new Vector3(panel.transform.position.x,panel.transform.position.y-Time.deltaTime*speed,panel.transform.position.z);
		}


	}



	public void clickToPanel(GameObject panel){
		if(firstTime == true){
			StartCoroutine (clickToPanelWait(panel));

		}



	}

	IEnumerator clickToPanelWait(GameObject panel){

		if(firstTime == true){
			
			firstTime = false;
			 
			yield return new WaitForSeconds (DELAY_B4_NEXT_TUT);

			SwitchToPanel.activatePanel (panel,this.allTutorialPanels);
		

			firstTime = true;
		}

	}


	/*this is used when player exists the game, want to close all panels, and not allow player to "pause" during the load*/
	public void closeAllPanels(){
		
		SwitchToPanel.closeAllPanels (this.allTutorialPanels);

	}

}
