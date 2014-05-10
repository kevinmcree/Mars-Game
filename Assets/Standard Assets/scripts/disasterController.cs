using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class disasterController : MonoBehaviour {
	
	Dictionary<ResourceType, float> ResourceDepleted = new Dictionary<ResourceType, float>();
	
	public float delay = 10; 
	public float dropRate = 50; //how often drops happen in seconds
	
	public GameObject building;
	private gameManager gameController;
	//private Random random = new Random();
	
	// Use this for initialization
	void Start () {
		/*ResourceDepleted[ResourceType.Power] = 0;
		ResourceDepleted[ResourceType.Water] = 0;
		ResourceDepleted[ResourceType.Oxygen] = 0;
		ResourceDepleted[ResourceType.Food] = 0;
		ResourceDepleted[ResourceType.Population] = 0;
		ResourceDepleted[ResourceType.Materials] = 0;

		if(gameController.resourcePool[ResourceType.Population] > 1000){
			dis = Random.Range(1, 4);

			if(dis == 1){// Water Contamination/Drought causes loss of water
				gameController.addResource(ResourceType.Water, -((5*gameController.resourcePool[ResourceType.Water])/100));
			}else if(dis == 2){// Meteor/Asteroid collision causes loss of oxygen
				gameController.addResource(ResourceType.Oxygen, -((3*gameController.resourcePool[ResourceType.Oxygen])/100));
			}else if(dis == 3){// Blackout
				gameController.addResource(ResourceType.Power, -((5*gameController.resourcePool[ResourceType.Power])/100));
			}else{//Famine
				gameController.addResource(ResourceType.Food, -((5*gameController.resourcePool[ResourceType.Food])/100));
			}
		}*/

		GameObject gameControllerObject = GameObject.Find ("gameManager");
		gameController = gameControllerObject.GetComponent <gameManager>();
		InvokeRepeating ("disaster", delay, dropRate);
		
	}
	
	void disaster(){
		int dis = Random.Range (1, 4);
		if(gameController.resourcePool[ResourceType.Population] > 1000){
			dis = Random.Range(1, 4);
			
			if(dis == 1){// Water Contamination/Drought causes loss of water
				gameController.addResource(ResourceType.Water, -((5*gameController.resourcePool[ResourceType.Water])/100));
			}else if(dis == 2){// Meteor/Asteroid collision causes loss of oxygen
				gameController.addResource(ResourceType.Oxygen, -((3*gameController.resourcePool[ResourceType.Oxygen])/100));
			}else if(dis == 3){// Blackout
				gameController.addResource(ResourceType.Power, -((5*gameController.resourcePool[ResourceType.Power])/100));
			}else{//Famine
				gameController.addResource(ResourceType.Food, -((5*gameController.resourcePool[ResourceType.Food])/100));
			}
		}
	}
	
}
