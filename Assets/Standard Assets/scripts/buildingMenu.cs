using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class buildingMenu : MonoBehaviour {
	
	public GameObject pp;
	public GameObject gh;
	public GameObject q;
	public GameObject wm;
	private gameManager gameController;
	
	// Use this for initialization
	void Start() {
		GameObject gameControllerObject = GameObject.Find("gameManager");
		gameController = gameControllerObject.GetComponent <gameManager>();
	}
	
	void buttonClicked(GameObject obj){
		if (!gameController.mouseHolding && gameController.ableToBuild(obj.GetComponent<abstractBuilding>())) {
			gameController.mouseHolding = true;
			GameObject building = (GameObject) Instantiate(obj, this.transform.position, new Quaternion(0, 0, 0, 0));
			obj.AddComponent<buildingPlacer>();
			foreach (KeyValuePair<ResourceType, float> ent in obj.GetComponent<abstractBuilding>().RequiredResources()) {
				gameController.addResource(ent.Key, -ent.Value);
			}
		}
	}
	
	void OnGUI () {
		// Make a background box
		GUI.Box(new Rect(10,100,100,150), "Building Menu");
		
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(20,130,80,20), "Powerplant")) {
			buttonClicked(pp);
		}
		
		// Make the second button.
		if(GUI.Button(new Rect(20,160,80,20), "Greenhouse")) {
			buttonClicked(gh);
		}
		
		if(GUI.Button(new Rect(20,190,80,20), "Quarters")) {
			buttonClicked(q);
		}

		if(GUI.Button(new Rect(20,220,80,20), "Water Mine")) {
			buttonClicked(wm);
		}
	}
}