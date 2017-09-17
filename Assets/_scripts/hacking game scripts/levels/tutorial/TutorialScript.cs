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


	public float SPAWN_CUBES_WAIT = 1.5f;

	//prefabs
	public GameObject tutorialCube_prefab;
	public GameObject moveHere_prefab;

	//player controller script
	private PlayerController player;
	private string playerTag = "Player";


	//instantiated prefabs 
	private GameObject tutorialCubes;
	private GameObject moveHere;

	public SwitchToPanel switchToPanelScript;

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

	}
	
	// Update is called once per frame
	void Update () {


		//tutorial 3A--------------------
		//when player finnishes cube tutorial, then pull up next tutorial panel
		if(tutorialCubes!=null && tutorialCubes.transform.childCount == 0 && !finnishedTutorialCubes){
			//close the all panel first
			switchToPanelScript.closeAllPanels (this.allTutorialPanels);
			//go to tutorial 4
			clickToPanel (tutorial4);

			finnishedTutorialCubes = true;
			Destroy (tutorialCubes);
		}

		if(tutorial3a.activeSelf == true){
			movePanelToBottom (tutorial3a);
		}

	
		//tutorial 5a---------------------------
		//if the move here was activated and player stepped on it,then go to next tutorial

		if(moveHere != null && moveHere.activeSelf == true){
			moveHereExists = true;
		}


		if(moveHereExists == true){
			if(moveHere == null){

				//generate an practise enemy
				GetComponent<TutorialLevel> ().generateEnemy();

				//close the all panel first
				switchToPanelScript.closeAllPanels (this.allTutorialPanels);
				//go to tutorial 6
				clickToPanel (tutorial6);



				moveHereExists = false;


			}
		}

		if(tutorial5a.activeSelf == true){
			movePanelToBottom (tutorial5a);
		}


		//tutorial 6 
		if(tutorial6 != null && tutorial6.activeSelf == true){
			Time.timeScale = 0;//pause until player clicks
		}
			

	}



	/*Click methods below*/


	//CUBE SPAWN
	public void clickToSpawnTutorialCubes(){

		if(spawnCubeOnce == true){
			StartCoroutine (spawnTutorialCubes());

			//close the all panel first
			switchToPanelScript.closeAllPanels (this.allTutorialPanels);

			//open tutorial 3a
			clickToPanel(tutorial3a);


		}


	}

	IEnumerator spawnTutorialCubes(){

		if (spawnCubeOnce == true) {
			spawnCubeOnce = false;
			//wait for SPAWN_CUBES_WAIT second before spawning tutorial cubes
			yield return new WaitForSeconds (SPAWN_CUBES_WAIT);
			tutorialCubes = GameObject.Instantiate<GameObject> (tutorialCube_prefab);
			tutorialCubes.transform.position = new Vector3 (0, tutorialCubes.GetComponentInChildren<Collider> ().bounds.size.y / 2, 0);

		}

	}

	//MOVE TO GLOWING AREA 
	public void clickToSpawnMoveToArea(){

		if(spawnMoveToOnce == true){
			StartCoroutine (spawnMoveToArea());

			//close the all panel first
			switchToPanelScript.closeAllPanels (this.allTutorialPanels);

			//open tutorial 5a
			clickToPanel(tutorial5a);


		}


	}

	IEnumerator spawnMoveToArea(){

		if (spawnMoveToOnce == true) {
			spawnMoveToOnce = false;
			//wait for SPAWN_CUBES_WAIT second before spawning tutorial cubes
			yield return new WaitForSeconds (SPAWN_CUBES_WAIT);
			moveHere = GameObject.Instantiate<GameObject> (moveHere_prefab);
			//tutorialCubes.transform.position = new Vector3 (0, 0.1, 0);

		}

	}





	private void movePanelToBottom(GameObject panel){

		if(panel.transform.position.y > 0){
			panel.transform.position = new Vector3(panel.transform.position.x,panel.transform.position.y-Time.deltaTime*500,panel.transform.position.z);
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

			yield return new WaitForSeconds (0.3f);

			switchToPanelScript.activatePanel (panel,this.allTutorialPanels);

			//allow mouse rotation at third tutorial panel
			if(panel == tutorial3){
				player.allowMouseRotation = true;
			}

			// allow movement at 5th tutorial panel
			if(panel == tutorial5){
				player.allowKeypressMovement = true;
			}

			firstTime = true;
		}

	}


	/*this is used when player exists the game, want to close all panels, and not allow player to "pause" during the load*/
	public void closeAllPanels(){
		
		switchToPanelScript.closeAllPanels (this.allTutorialPanels);

	}

}
