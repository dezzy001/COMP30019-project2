using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tabButtonScript : MonoBehaviour {

	//tab buttons
	public Button chipTabButton;
	public Button skillTabButton;
	public Button skinTabButton;


	//tab panels
	public GameObject chipTabPanel;
	public GameObject skillTabPanel;
	public GameObject skinTabPanel;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		activePanel(chipTabPanel, chipTabButton);
		activePanel(skillTabPanel, skillTabButton);
		activePanel(skinTabPanel, skinTabButton);
	}


	//if panel is active, then respective button will be a different shade of color
	void activePanel(GameObject panel, Button button){
		if (panel.activeSelf == true) {
			button.image.color = new Color (0.75f, 0.75f, 0.75f);
		} else {
			button.image.color = Color.white;
		}
	}

}
