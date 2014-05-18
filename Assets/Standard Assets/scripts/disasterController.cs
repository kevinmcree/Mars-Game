using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class disasterController : MonoBehaviour {
	
	Dictionary<ResourceType, float> ResourceDepleted = new Dictionary<ResourceType, float>();
	
	public float delay; 
	public float dropRate; //how often drops happen in seconds
	
	public GameObject building;
	private gameManager gameController;
	
	// Use this for initialization
	void Start () {

		GameObject gameControllerObject = GameObject.Find ("gameManager");
		gameController = gameControllerObject.GetComponent <gameManager>();
		InvokeRepeating ("disaster", delay, dropRate);
		
	}

	//Disaster now emptys a random storage building. Can be modified to strike multiple buildings
	void disaster(){
		if(gameController.getCurrentResource(ResourceType.Population) > 500){
			storageBuilding[] objs = (storageBuilding[]) GameObject.FindObjectsOfType(typeof(storageBuilding));
			storageBuilding target = objs[Random.Range(0,objs.Length)];
			foreach(KeyValuePair<ResourceType, float> ent in target.ResourceInStorage){
				target.ResourceInStorage[ent.Key] = 0;
			}
		}
	}

	
}
