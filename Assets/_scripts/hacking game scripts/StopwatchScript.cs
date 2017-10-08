using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.UI;

public class StopwatchScript : MonoBehaviour {

	public GameObject hackingCompletePanel;
	public Text stopwatchText;
	public Stopwatch timer;



	// Use this for initialization
	void Start () {
		timer = new Stopwatch ();
		timer.Start();
	}
	
	// Update is called once per frame
	void Update () {

		stopwatchText.text = timer.Elapsed.ToString();

		if (hackingCompletePanel.activeSelf == true) {
			timer.Stop();
		}
	}
}
