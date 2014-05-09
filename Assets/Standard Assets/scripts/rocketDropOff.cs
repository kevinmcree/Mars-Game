using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class rocketDropOff : MonoBehaviour {

	Dictionary<ResourceType, float> ResourcesPerDrop = new Dictionary<ResourceType, float>();

	public float delay = 10; 
	public float dropRate = 50; //how often drops happen in seconds
	
	public GameObject building;
	private gameManager gameController;
	//private Random random = new Random();
	
	// Use this for initialization
	void Start () {
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

	void dropOff(){
		foreach(KeyValuePair<ResourceType, float> ent in ResourcesPerDrop){
			gameController.addResource(ent.Key, ent.Value);
		}
	}

}
