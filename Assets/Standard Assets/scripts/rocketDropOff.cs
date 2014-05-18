using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class rocketDropOff : MonoBehaviour {

	Dictionary<ResourceType, float> ResourcesPerDrop = new Dictionary<ResourceType, float>();

	public float delay; 
	public float dropRate; //how often drops happen in seconds
	
	public GameObject building;
	private gameManager gameController;
	//private Random random = new Random();
	
	// Use this for initialization
	void Start () {
		//ALERT
		//This code currently makes the drops random, HOWEVER it's a single random
		//value throught the entire play. Each drop will have the exact same resources
		//ALERT
		ResourcesPerDrop[ResourceType.Power] = Random.Range(0, 50);
		ResourcesPerDrop[ResourceType.Water] = Random.Range(0, 50);
		ResourcesPerDrop[ResourceType.Oxygen] = Random.Range(0, 50);
		ResourcesPerDrop[ResourceType.Food] = Random.Range(50, 100);
		ResourcesPerDrop[ResourceType.Population] = Random.Range(1, 10);
		ResourcesPerDrop[ResourceType.Materials] = Random.Range(50, 100);

		GameObject gameControllerObject = GameObject.Find ("gameManager");
		gameController = gameControllerObject.GetComponent <gameManager>();
		InvokeRepeating ("dropOff", delay, dropRate);

	}

	void Update() {
		ResourcesPerDrop[ResourceType.Power] = Random.Range(0, 50);
		ResourcesPerDrop[ResourceType.Water] = Random.Range(0, 50);
		ResourcesPerDrop[ResourceType.Oxygen] = Random.Range(0, 50);
		ResourcesPerDrop[ResourceType.Food] = Random.Range(50, 100);
		ResourcesPerDrop[ResourceType.Population] = Random.Range(1, 10);
		ResourcesPerDrop[ResourceType.Materials] = Random.Range(50, 100);
	}

	void dropOff(){
		//Drops are made at the Core Base
		CoreBase cBase = GameObject.Find("coreBase").GetComponent<CoreBase>();
		foreach(KeyValuePair<ResourceType, float> ent in ResourcesPerDrop){
			cBase.addResource(ent.Key, ent.Value);
		}
	}

}
