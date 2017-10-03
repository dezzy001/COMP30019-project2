using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelScript : MonoBehaviour {

	//when game complete show the hacking complete panel
	public GameObject hackingCompletePanel;
	private float HACKING_PANEL_WAIT = 0.3f;

	public bool gameStarted = false;


	public void setEnemiesToChild(){
		foreach(Transform child in transform){
			child.transform.parent = this.transform;
		}
	}


	//turn off the sheild for boss if only it is the only one left
	public void oneBossLeft(GameObject enemyBoss){
		Transform[] enemyBoss1Transform = enemyBoss.GetComponentsInChildren<Transform>();

		foreach(Transform enemyBody in enemyBoss1Transform){
			if(enemyBody.tag == "BossShield"){

				ParticleSystem[] enemyParticleSystems =  enemyBody.GetComponentsInChildren<ParticleSystem> ();
				foreach(ParticleSystem enemyParticle in enemyParticleSystems){
					enemyParticle.Stop ();
				}
			}
		}
		enemyBoss.tag = "Enemy";
	}




	/*Hacking panel related*/
	public void showHackingPanel(){
		StartCoroutine (showHackingPanelDelay());
	}


	IEnumerator showHackingPanelDelay() {

		//wait for 1 second before showing hacking panel and the cursour
		yield return new WaitForSeconds (HACKING_PANEL_WAIT);


		hackingCompletePanel.SetActive(hackingCompletePanel);
		Cursor.visible = true;

	}

}
