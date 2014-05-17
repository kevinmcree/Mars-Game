using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class gameManager : MonoBehaviour {

	public bool mouseHolding = false;
	
	Dictionary<ResourceType, GUIText> resourceTexts = new Dictionary<ResourceType, GUIText>();
	
	public float deathRate = -.01f;
	public GUIText powerText;
	public GUIText waterText;
	public GUIText oxygenText;
	public GUIText foodText;
	public GUIText populationText;
	public GUIText materialsText;
	//public Rect windowRect = new Rect(250,100,140,300);

	// Use this for initialization
	void Start() {
		Time.timeScale = 1;

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

}
