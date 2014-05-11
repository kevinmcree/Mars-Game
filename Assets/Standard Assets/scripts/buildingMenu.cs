using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class buildingMenu : MonoBehaviour {
	
	public GameObject pp;
	public GameObject gh;
	public GameObject q;
	public GameObject wm;
	public Texture2D ppSprite;
	public Texture2D ghSprite;
	public Texture2D qSprite;
	public Texture2D wmSprite;
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
		GUI.Box(new Rect(10,100,140,250), "Building Menu");
		
		// Make the first button.
		if(GUI.Button(new Rect(20,130,120,40), new GUIContent("Powerplant", ppSprite))) {
			buttonClicked(pp);
		}
		
		// Make the second button.
		if(GUI.Button(new Rect(20,180,120,40), new GUIContent("Greenhouse", ghSprite))) {
			buttonClicked(gh);
		}
		
		if(GUI.Button(new Rect(20,230,120,40), new GUIContent("Quarters", qSprite))) {
			buttonClicked(q);
		}

		if(GUI.Button(new Rect(20,280,120,40), new GUIContent("Water Mine", wmSprite))) {
			buttonClicked(wm);
		}
	}
}