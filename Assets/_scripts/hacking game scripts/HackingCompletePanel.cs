using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//must always keep this gameobject inactive (unticked in editor)
public class HackingCompletePanel : MonoBehaviour {

	public PauseScript pauseScript;

	//to get the blur script
	private Component[] cameraScripts;
	private MonoBehaviour blurScript;
	private string blurScriptFileName = "BlurOptimized";

	// Use this for initialization
	void Start () {


		pauseScript.allowPauseKey = false;

		cameraScripts = GameObject.Find ("Main Camera").GetComponents<MonoBehaviour>();


		foreach(MonoBehaviour blur in cameraScripts){

			if (blur.GetType ().Name == blurScriptFileName) {
				blurScript = blur;
				blurScript.enabled = false;
			} 

		}

		blurScript.enabled = true;
	}
	

}
