using System.Collections;
using System.Collections.Generic;
using UnityEngine;




/*

This class is to be drag and dropped on: Tutorial Panel 5

*/
public class tutorialMoveScript : MonoBehaviour {


	public float DELAY_B4_NEXT_TUT = 1.8f;
	public GameObject nextPanel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	
		if(Input.GetAxis ("Horizontal") > 0.5f || Input.GetAxis ("Vertical") > 0.5f){
			StartCoroutine (delayBeforeNextTutorial());
		}
	}



	IEnumerator delayBeforeNextTutorial(){
		yield return new WaitForSeconds (DELAY_B4_NEXT_TUT);

		nextPanel.SetActive (true);
		this.gameObject.SetActive (false);
	}
}
