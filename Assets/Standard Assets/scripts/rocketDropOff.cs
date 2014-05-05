using UnityEngine;
using System.Collections;

public class rocketDropOff : MonoBehaviour {
	public float power;
	public float water;
	public float oxygen;
	public float food;
	public float population;
	public float materials;
	public float delay; 
	public float dropRate; //how often drops happen in seconds
	
	public GameObject building;
	private gameManager gameController;
	
	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.Find ("gameManager");
		gameController = gameControllerObject.GetComponent <gameManager>();
		InvokeRepeating ("dropOff", delay, dropRate);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void dropOff(){
		/*
		gameController.addPower(power);
		gameController.addWater(water);
		gameController.addOxygen(oxygen);
		gameController.addFood(food);
		gameController.addPopulation(population);
		gameController.addMaterials(materials);
		*/
	}

}
