using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleTime : MonoBehaviour {

	public void timeOn(){

		Time.timeScale = 1;
	}

	public void timeOff(){
		Time.timeScale = 0;

	}
}
