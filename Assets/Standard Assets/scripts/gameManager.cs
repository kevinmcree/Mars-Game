using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class gameManager : MonoBehaviour {

	public bool mouseHolding = false;
	
	Dictionary<ResourceType, GUIText> resourceTexts = new Dictionary<ResourceType, GUIText>();
	
	public float deathRate = -.01f;
	public float timer;
	public GUIText powerText;
	public GUIText waterText;
	public GUIText oxygenText;
	public GUIText foodText;
	public GUIText populationText;
	public GUIText materialsText;
	public bool sustainable;

	private float powerPrev;
	private float waterPrev;
	private float oxygenPrev;
	private float foodPrev;
	private float populationPrev;
	private float materialsPrev;

	// Use this for initialization
	void Start() {
		Time.timeScale = 1;
		sustainable = false;

		resourceTexts[ResourceType.Food] = foodText;
		resourceTexts[ResourceType.Materials] = materialsText;
		resourceTexts[ResourceType.Oxygen] = oxygenText;
		resourceTexts[ResourceType.Population] = populationText;
		resourceTexts[ResourceType.Power] = powerText;
		resourceTexts[ResourceType.Water] = waterText;

		foreach (ResourceType type in (ResourceType[])Enum.GetValues(typeof(ResourceType))) {
			updateResource(type);
		}

		updatePrev ();
	}
	
	// Update is called once per frame
	void Update() {
		//If out of WATER or FOOD or OXYGEN, begin killing off people in 
		//whatever storage building the engine gives you first with people
		if(getCurrentResource(ResourceType.Water) == 0 ||
		   getCurrentResource(ResourceType.Food) == 0 ||
		   getCurrentResource(ResourceType.Oxygen) == 0){
			storageBuilding[] objs = (storageBuilding[]) GameObject.FindObjectsOfType(typeof(storageBuilding));
			foreach(storageBuilding build in objs){
				if(build.getResourceInStorage(ResourceType.Population) > 0){
					build.addResource(ResourceType.Population, deathRate);
					return;
				}
			}
		}
		
		//Update all the resource displays
		foreach (ResourceType type in (ResourceType[])Enum.GetValues(typeof(ResourceType))) {
			updateResource(type);
		}

		//Check for sustainability
		checkSustainability ();

		updatePrev ();

		GameObject go = GameObject.Find("menu");
		if (go.GetComponent<buildingMenu>().show==true){
			audio.Pause();
		}
	}

	//Updates the Gui string for the passed resource type
	public void updateResource(ResourceType res) {
		//Grabs all the buildings
		abstractBuilding[] objs = (abstractBuilding[]) GameObject.FindObjectsOfType(typeof(abstractBuilding));
		float currentRes = 0;
		float maxRes = 0;
		//loop through all the buildings
		foreach(abstractBuilding build in objs) {
			//if the building is inactive, ignore it
			if(!build.isActive){continue;}
			//otherwise, add the stored resources and the max storage to the count
			currentRes += build.getResourceInStorage(res);
			maxRes += build.getResourceStorage(res);
		}
		//Update the actual string
		resourceTexts[res].text = res.ToString() + ": " + currentRes.ToString("0") + " / " + maxRes.ToString("0");
	}

	//Gets the current amount of resources on hand
	public float getCurrentResource(ResourceType res){
		//Grab all the buildings
		abstractBuilding[] objs = (abstractBuilding[]) GameObject.FindObjectsOfType(typeof(abstractBuilding));
		float currentRes = 0;
		//For each building
		foreach(abstractBuilding build in objs) {
			//if the building is inactive, ignore it
			if(!build.isActive){continue;}
			//otherwise, add the amount of resource in storage to the count
			currentRes += build.getResourceInStorage(res);
		}
		return currentRes;
	}

	//Check if a building can be built
	public bool ableToBuild(abstractBuilding ab){
		//Check each resource type required
		foreach (KeyValuePair<ResourceType, float> res in ab.ResourceToBuild) {
			//if the global count for the resource is lower than the required amount
			if (res.Value > getCurrentResource(res.Key)){
				//the building cannot be built
				return false;
			}
		}
		//if all resources are available, building can be built
		return true;
	}

	public void updatePrev (){
		powerPrev = getCurrentResource (ResourceType.Power);
		waterPrev = getCurrentResource (ResourceType.Water);
		oxygenPrev = getCurrentResource (ResourceType.Oxygen);
		foodPrev = getCurrentResource (ResourceType.Food);
		populationPrev = getCurrentResource (ResourceType.Population);
		materialsPrev = getCurrentResource (ResourceType.Materials);
	}

	public void checkSustainability(){
		if (getCurrentResource (ResourceType.Power) >= powerPrev &&
			getCurrentResource (ResourceType.Water) >= waterPrev &&
			getCurrentResource (ResourceType.Oxygen) >= oxygenPrev &&
			getCurrentResource (ResourceType.Food) >= foodPrev &&
			getCurrentResource (ResourceType.Population) >= populationPrev &&
			getCurrentResource (ResourceType.Materials) >= materialsPrev) {
			if(!sustainable){
				timer = Time.time;
			}
			sustainable = true;
		}else {
			sustainable = false;
		}
	}

}
