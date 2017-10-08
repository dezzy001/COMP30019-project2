using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.UI;

public class StopwatchScript : MonoBehaviour {

	public GameObject hackingCompletePanel;
	public Text stopwatchText;
	public GameObject stopwatchPanel;
	public Stopwatch timer;

	public GameObject loadingPanel;



	// Use this for initialization
	void Start () {
		timer = new Stopwatch ();
		timer.Start();
	}
	
	// Update is called once per frame
	void Update () {

		string splitStopwatchText = timer.Elapsed.ToString().Split('.')[0];


		stopwatchText.text = splitStopwatchText;

		if (hackingCompletePanel.activeSelf == true) {
			timer.Stop();
		}

		if(loadingPanel.activeSelf == true){
			stopwatchPanel.SetActive (false);
		}
	}
}
