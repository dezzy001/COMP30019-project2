using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleTime : MonoBehaviour {

	public static void timeOn(){

		Time.timeScale = 1;
	}

	public static void timeOff(){
		Time.timeScale = 0;

	}
}
