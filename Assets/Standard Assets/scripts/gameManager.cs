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
	public GUIText greenHouseText;
	public GUIText powerPlantText;
	public GUIText quartersText;


	// Use this for initialization
	void Start() {
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

		greenHouseText.text = "Greenhouse";
		powerPlantText.text = "Powerplant";
		quartersText.text = "Quarters";
	}
	
	// Update is called once per frame
	void Update() {
		addResource(ResourceType.Food, -.01f*resourcePool[ResourceType.Population]);
		addResource(ResourceType.Water, -.004f*resourcePool[ResourceType.Population]);
		addResource(ResourceType.Oxygen, -.004f*resourcePool[ResourceType.Population]);


		if(resourcePool[ResourceType.Water] == 0 || resourcePool[ResourceType.Food] == 0 || resourcePool[ResourceType.Oxygen] == 0){
			addResource(ResourceType.Population, deathRate);
		}

	}
	
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
