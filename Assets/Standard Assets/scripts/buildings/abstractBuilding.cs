using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * Base Building to inherit from. Adds no resources if somehow instantiated.
 */
public class abstractBuilding : MonoBehaviour {

	protected Dictionary<ResourceType, float> ResourcePerUpdate = new Dictionary<ResourceType, float>();

	public float materialsToBuild = 0; //Units of Materials required/consumed to build
	public float manHours = 0; //Man hours needed to construct the building
	public float maxOxygenVolume = 0; //Units of Oxygen needed to fill a building when initially constructed or if a leak occurs
	public float currentOxygenVolume = 0;

	protected gameManager gameController;

	//Determines if building is actively producing resources
	public bool isActive = true;

	// Use this for initialization
	protected virtual void Start() {
		GameObject gameControllerObject = GameObject.Find("gameManager");
		gameController = gameControllerObject.GetComponent <gameManager>();
	}
	
	// Update is called once per frame
	protected virtual void Update() {
		//BEGIN add resources to pool if active
		if (isActive) {
			foreach(KeyValuePair<ResourceType, float> ent in ResourcePerUpdate){
				gameController.addResource(ent.Key, ent.Value);
			}
		}
		//END add resources to pool if active
	}
}
