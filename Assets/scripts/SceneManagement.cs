using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour {

	void Start(){
		//allows app to run in background, multitask
		Application.runInBackground = true; 
	}

	public void changeScene(string sceneName){

		SceneManager.LoadScene ( sceneName);

	}
}
