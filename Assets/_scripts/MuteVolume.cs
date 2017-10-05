using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteVolume : MonoBehaviour {

	public bool isMute = false;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		

	}



	public void muteSoud(){
		
		if (isMute == false) {
			AudioListener.pause = true;
			AudioListener.volume = 0;
			isMute = !isMute;
		} else {
			AudioListener.pause = false;
			AudioListener.volume = 1;
			isMute = !isMute;
		}

	}
}
