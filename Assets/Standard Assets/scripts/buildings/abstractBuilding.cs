﻿using UnityEngine;
using System.Collections;

/*
 * Base Building to inherit from. Adds no resources if somehow instantiated.
 */
public class abstractBuilding : MonoBehaviour {

	public float power = 0; //Units of Power produced per update
	public float water = 0; //Units of Water produced per update
	public float oxygen = 0; //Units of Oxygen produced per update
	public float food = 0; //Units of Food produced per update
	public float materials = 0; //Units of Building Materials produced per update

	public float materialsToBuild = 0; //Units of Materials required/consumed to build
	public float manHours = 0; //Man hours needed to construct the building
	public float oxygenVolume = 0; //Units of Oxygen needed to fill a building when initially constructed or if a leak occurs

	private gameManager gameController;

	//Determines if building is actively producing resources
	public bool isActive{ get { return isactive; } }

	private bool isactive = true;

	//Sets if building is actively producing resources
	public void setActive(bool active) {
		isactive = active;
	}

	// Use this for initialization
	protected virtual void Start() {
		GameObject gameControllerObject = GameObject.Find("gameManager");
		gameController = gameControllerObject.GetComponent <gameManager>();
	}
	
	// Update is called once per frame
	protected virtual void Update() {
		//BEGIN add resources to pool if active
		if (isActive) {
			gameController.addPower(power);
			gameController.addWater(water);
			gameController.addOxygen(oxygen);
			gameController.addFood(food);
			gameController.addMaterials(materials);
		}
		//END add resources to pool if active
	}
}
