using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class builldingButton : MonoBehaviour {
	
	public GameObject building;
	private gameManager gameController;

	// Use this for initialization
	void Start() {
		GameObject gameControllerObject = GameObject.Find("gameManager");
		gameController = gameControllerObject.GetComponent <gameManager>();
	}
	
	// Update is called once per frame
	void Update() {
	
	}

	void OnMouseUp() {
		if (gameController.ableToBuild(building.GetComponent<abstractBuilding>())) {
			GameObject obj = (GameObject) Instantiate(building, this.transform.position, new Quaternion(0, 0, 0, 0));
			obj.AddComponent<buildingPlacer>();
			foreach (KeyValuePair<ResourceType, float> ent in building.GetComponent<abstractBuilding>().RequiredResources()) {
				gameController.addResource(ent.Key, -ent.Value);
			}


		}
	}
}
