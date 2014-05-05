using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class rocketDropOff : MonoBehaviour {

	Dictionary<ResourceType, float> ResourcesPerDrop = new Dictionary<ResourceType, float>();

	public float delay = 10; 
	public float dropRate = 30; //how often drops happen in seconds
	
	public GameObject building;
	private gameManager gameController;
	
	// Use this for initialization
	void Start () {
		ResourcesPerDrop[ResourceType.Power] = 100;
		ResourcesPerDrop[ResourceType.Water] = 100;
		ResourcesPerDrop[ResourceType.Oxygen] = 100;
		ResourcesPerDrop[ResourceType.Food] = 100;
		ResourcesPerDrop[ResourceType.Population] = 1;
		ResourcesPerDrop[ResourceType.Materials] = 100;

		GameObject gameControllerObject = GameObject.Find ("gameManager");
		gameController = gameControllerObject.GetComponent <gameManager>();
		InvokeRepeating ("dropOff", delay, dropRate);

	}

	void dropOff(){
		foreach(KeyValuePair<ResourceType, float> ent in ResourcesPerDrop){
			gameController.addResource(ent.Key, ent.Value);
		}
	}

}
