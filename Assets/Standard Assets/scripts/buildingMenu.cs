using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class buildingMenu : MonoBehaviour {
	
	public GameObject pp;
	public GameObject gh;
	public GameObject q;
	public GameObject wm;
	public GameObject im;
	public Texture2D ppSprite;
	public Texture2D ghSprite;
	public Texture2D qSprite;
	public Texture2D wmSprite;
	public Texture2D imSprite;
	private int menuWidth;
	private int menuHeight;
	private gameManager gameController;
	
	// Use this for initialization
	void Start() {
		GameObject gameControllerObject = GameObject.Find("gameManager");
		gameController = gameControllerObject.GetComponent <gameManager>();
		menuWidth = 140;
		menuHeight = 200;
	}
	
	void buttonClicked(GameObject obj){
		if (!gameController.mouseHolding && gameController.ableToBuild(obj.GetComponent<abstractBuilding>())) {
			gameController.mouseHolding = true;
			GameObject bd = (GameObject) Instantiate(obj, Camera.main.ScreenToWorldPoint(Input.mousePosition), new Quaternion(0, 0, 0, 0));
			bd.transform.eulerAngles = new Vector3(0,180,0);
			foreach (KeyValuePair<ResourceType, float> ent in obj.GetComponent<abstractBuilding>().RequiredResources()) {
				gameController.addResource(ent.Key, -ent.Value);
			}
		}

	}
	
	void OnGUI () {
		// Make a background box
		GUI.Box(new Rect(10,100,menuWidth,menuHeight), "Building Menu");
		
		// Make the first button.
		addButton (pp, ppSprite, "Powerplant", 20, 130, 120, 40);
		addButton (gh, ghSprite, "Greenhouse", 20, 180, 120, 40);
		addButton (q, qSprite, "Quarters", 20, 230, 120, 40);

		if (gameController.resourcePool [ResourceType.Population] > 5) {
			if (gameController.resourcePool[ResourceType.Population] < 10){
				menuHeight = 250;
			}
			addButton (wm, wmSprite, "Water Mine", 20, 280, 120, 40);
		}

		if (gameController.resourcePool [ResourceType.Population] > 10) {
			menuHeight = 300;
			addButton (im, imSprite, "Iron Mine", 20, 330, 120, 40);
		}

	}

	void addButton (GameObject obj, Texture2D sprite, string txt, int x, int y, int width, int height) {
		if(GUI.Button(new Rect(x, y, width, height), new GUIContent(txt, sprite))) {
			buttonClicked(obj);
		}
	}
}