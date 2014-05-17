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
	public Rect windowR = new Rect(500,100,150,150);

	private int menuWidth;
	private int menuHeight;
	public bool show = false;
	private bool unlockWM = false;
	private bool unlockIM = false;
	private gameManager gameController;
	bool toggle = true;
	
	// Use this for initialization
	void Start() {
		GameObject gameControllerObject = GameObject.Find("gameManager");
		gameController = gameControllerObject.GetComponent <gameManager>();
		menuWidth = 140;
		menuHeight = 200;
		Time.timeScale = 1;
	}
	
	void buttonClicked(GameObject obj){
		if (!gameController.mouseHolding && gameController.ableToBuild(obj.GetComponent<abstractBuilding>())) {
			gameController.mouseHolding = true;
			GameObject bd = (GameObject) Instantiate(obj, Camera.main.ScreenToWorldPoint(Input.mousePosition), new Quaternion(0, 0, 0, 0));
			bd.transform.eulerAngles = new Vector3(0,180,0);
			//audio.Play(); 
		}

	}
	
	void OnGUI () {
		// Make a background box
		GUI.Box(new Rect(10, 100, menuWidth, menuHeight), "Building Menu");

		addButton (pp, ppSprite, "Powerplant", 130);
		addButton (gh, ghSprite, "Greenhouse", 180);
		addButton (q, qSprite, "Quarters", 230);

		if (gameController.getCurrentResource(ResourceType.Population) > 10) {
			unlockWM = true;
			/*if (gameController.resourcePool[ResourceType.Population] < 10){
				menuHeight = 250;
			}
			addButton (wm, wmSprite, "Water Mine", 20, 280, 120, 40);*/
		}

		if (gameController.getCurrentResource(ResourceType.Population) > 20) {
			unlockIM = true;
			/*menuHeight = 300;
			addButton (im, imSprite, "Iron Mine", 20, 330, 120, 40);*/
		}

		if (unlockWM && !unlockIM) {
			menuHeight = 250;
			addButton (wm, wmSprite, "Water Mine", 280);
		} else if (unlockWM && unlockIM) {
			menuHeight = 300;
			addButton (wm, wmSprite, "Water Mine", 280);
			addButton (im, imSprite, "Iron Mine", 330);
		}

		if (gameController.getCurrentResource(ResourceType.Population) < 0) {
			show = true;
			//windowRect = GUI.Window(0, windowRect, DoMyWindow, "Your Population Hit 0!");
		}

		// End game display
		if (show) {
			Time.timeScale = 0;
			windowR = GUI.Window(0, windowR, DoMyWindow, "Your Population Hit 0!");
			if (toggle){
				audio.Play(); 
				toggle = false;
			}
		}
	}

	void DoMyWindow(int windowID) {
		if (GUI.Button(new Rect(25, 50, 100, 40), "Start Over")){
			Application.LoadLevel("main game");
		}
		
		/*if (GUI.Button(new Rect(10, 50, 100, 40), "Continue")){
			closeWindow();
		}*/
	}

	void closeWindow(){
		show = false;
	}

	void addButton (GameObject obj, Texture2D sprite, string txt, int y) {
		if(GUI.Button(new Rect(20, y, 120, 40), new GUIContent(txt, sprite))) {
			buttonClicked(obj);
		}
	}
}