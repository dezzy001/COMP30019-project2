using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSwitchPanelScript : MonoBehaviour {


	public IEnumerator delayBeforeNextTutorial(GameObject nextPanel, float DELAY_B4_NEXT_TUT){

		yield return new WaitForSeconds (DELAY_B4_NEXT_TUT);

		nextPanel.SetActive (true);
		this.gameObject.SetActive (false);
	}
}
