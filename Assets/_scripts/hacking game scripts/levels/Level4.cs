using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4 : MonoBehaviour {

	//when game complete show the hacking complete panel
	public GameObject hackingCompletePanel;
	private bool gameStarted = false;
	private float HACKING_PANEL_WAIT = 0.3f;

	public GameObject enemyBoss1;


	// Use this for initialization
	void Start () {

		foreach(Transform child in transform){
			child.transform.parent = this.transform;
		}

		gameStarted = true;




	}
	
	// Update is called once per frame
	void Update () {

		// debug
		//print(transform.childCount == 1);
		print(enemyBoss1);

		if(gameStarted == true){
			
			if(transform.childCount == 0){

				print ("Show hacking panel");
				StartCoroutine (showHackingPanel());

			}

			if (transform.childCount == 1){
				//turn off the sheild for boss if only it is the only one left
				print ("works");

				//GameObject enemyBoss1BodyPart = GameObject.Find ("EnemyBoss1/EnemyBoss1 BodyPart");

				ParticleSystem enemyBoss1Particle = enemyBoss1.GetComponentsInChildren<ParticleSystem>() [2];
				enemyBoss1Particle.Stop ();

				enemyBoss1.tag = "Enemy";


			}

		}
	}

	IEnumerator showHackingPanel() {

		print ("1 hack");

		//wait for 1 second before showing hacking panel and the cursour
		yield return new WaitForSeconds (HACKING_PANEL_WAIT);

		print ("2");

		hackingCompletePanel.SetActive(hackingCompletePanel);
		Cursor.visible = true;

	}

}
