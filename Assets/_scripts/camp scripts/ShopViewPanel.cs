using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ShopViewPanel : MonoBehaviour {

	public Button chipsButton;
	public GameObject chipsPanel;

	public Button skillsButton;
	public GameObject skillsPanel;

	public Button skinsButton;
	public GameObject skinsPanel;


	private ArrayList allTabPanels;


	void Start(){

		allTabPanels = new ArrayList ();

		allTabPanels.Add (chipsPanel);
		allTabPanels.Add (skillsPanel);
		allTabPanels.Add (skinsPanel);

		chipsButton.onClick.AddListener (() => switchPanelTab( chipsPanel));
		skillsButton.onClick.AddListener (() => switchPanelTab( skillsPanel));
		skinsButton.onClick.AddListener (() => switchPanelTab( skinsPanel));

	}

	void Update () {
		
	}


	void switchPanelTab(GameObject panel){
		//SwitchToPanel.closeAllPanels (allTabPanels);
		SwitchToPanel.activatePanel (panel,allTabPanels);

	}



}
