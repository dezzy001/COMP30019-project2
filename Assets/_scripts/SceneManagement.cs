using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagement : MonoBehaviour {


	public GameObject loadingPanel;
	public Slider loadingBarSlider;


	void Start(){
		//allows app to run in background, multitask
		Application.runInBackground = true; 

		//only have this active when loading
		loadingPanel.SetActive (false);
	}


	public void changeScene(string sceneName){



		StartCoroutine (LoadAsynchronously(sceneName));

		//SceneManager.LoadScene (sceneName);

		//AsyncOperation operation = SceneManager.LoadSceneAsync (sceneName);


	}

	public void retryScene(){
		string currSceneName = SceneManager.GetActiveScene ().name;
		playerDeathEvent.playerDead = false; // set player to alive again
		StartCoroutine (LoadAsynchronously(currSceneName));
	}


	IEnumerator LoadAsynchronously(string sceneName){

		//open up the loading panel
		loadingPanel.SetActive (true);
		//the scenes are so simple... they load in a split second, make it wait x secs to demonstrate loading page
		yield return new WaitForSeconds (1);

		//preloads the next scene, while still in the current scene
		AsyncOperation operation = SceneManager.LoadSceneAsync (sceneName);



		//while the next scene has not loaded , show the loading progress
		while(!operation.isDone){


			//unity loads in 2 stages, (1) loading 0 - 0.9 , (2)activation 0.9 - 10(deletes old stuff and replaces with new scene)
			float progress = Mathf.Clamp01 (operation.progress / 0.9f);

			loadingBarSlider.value = progress;

			yield return null;
		}



	}
}
