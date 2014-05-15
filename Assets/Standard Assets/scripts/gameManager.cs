using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class gameManager : MonoBehaviour {

	public bool mouseHolding = false;

	public Dictionary<ResourceType, float> resourcePool = new Dictionary<ResourceType, float>();
	Dictionary<ResourceType, GUIText> resourceTexts = new Dictionary<ResourceType, GUIText>();
	
	public float deathRate = -.01f;
	public GUIText powerText;
	public GUIText waterText;
	public GUIText oxygenText;
	public GUIText foodText;
	public GUIText populationText;
	public GUIText materialsText;
	//public Rect windowRect = new Rect(250,100,140,300);

	private int maxPopulation;

	// Use this for initialization
	void Start() {
		Time.timeScale = 1;
		maxPopulation = 20;
		resourcePool[ResourceType.Food] = 200;
		resourcePool[ResourceType.Materials] = 200;
		resourcePool[ResourceType.Oxygen] = 200;
		resourcePool[ResourceType.Population] = 5;
		resourcePool[ResourceType.Power] = 200;
		resourcePool[ResourceType.Water] = 200;


		resourceTexts[ResourceType.Food] = foodText;
		resourceTexts[ResourceType.Materials] = materialsText;
		resourceTexts[ResourceType.Oxygen] = oxygenText;
		resourceTexts[ResourceType.Population] = populationText;
		resourceTexts[ResourceType.Power] = powerText;
		resourceTexts[ResourceType.Water] = waterText;

		foreach (ResourceType type in (ResourceType[])Enum.GetValues(typeof(ResourceType))) {
			updateResource(type);
		}
	}
	
	// Update is called once per frame
	void Update() {
		addResource(ResourceType.Food, -.005f*resourcePool[ResourceType.Population]);
		addResource(ResourceType.Water, -.004f*resourcePool[ResourceType.Population]);
		addResource(ResourceType.Oxygen, -.004f*resourcePool[ResourceType.Population]);


		if(resourcePool[ResourceType.Water] == 0 || resourcePool[ResourceType.Food] == 0 || resourcePool[ResourceType.Oxygen] == 0){
			addResource(ResourceType.Population, deathRate);
		}

	}

	/*void OnGUI () {
		if (resourcePool[ResourceType.Population] < 1) {
			Time.timeScale = 0;
			windowRect = GUI.Window(0, windowRect, DoMyWindow, "Your Population Hit 0!");
			GUI.Box(new Rect(500,100,140,300), "Your Population Hit 0!");
			if (GUI.Button(new Rect(260, 130, 100, 40), "Start Over")){
				Application.LoadLevel("main game");
			}
			if (GUI.Button(new Rect(280, 130, 100, 40), "Continue")){
				Time.timeScale =1;
			}
		}
	}

	void DoMyWindow(int windowID) {
		if (GUI.Button(new Rect(260, 130, 100, 40), "Start Over")){
			Application.LoadLevel("main game");
		}

		if (GUI.Button(new Rect(280, 130, 100, 40), "Continue")){
			Time.timeScale =1;
		}
	}*/
	
	//these statements are all called by other functions to update the values held in the controller
	public void addResource(ResourceType res, float value) {
		resourcePool[res] += value;
		if (resourcePool[res] < 0) {
			resourcePool[res] = 0;
		}
		updateResource(res);
	}

	public void updateResource(ResourceType res) {
		resourceTexts[res].text = res.ToString() + ": " + resourcePool[res].ToString("0");
	}

	public bool ableToBuild(abstractBuilding ab){
		foreach (KeyValuePair<ResourceType, float> res in ab.RequiredResources()) {
			if (res.Value > resourcePool[res.Key]){
				return false;
			}
		}
		return true;
	}

}
