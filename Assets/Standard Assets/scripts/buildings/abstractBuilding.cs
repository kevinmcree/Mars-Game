using UnityEngine;
using System.Collections;

public class abstractBuilding : MonoBehaviour {

	public float power = 0;
	public float water = 0;
	public float oxygen = 0;
	public float food = 0;
	public float materials = 0;

	private gameManager gameController;

	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.Find ("gameManager");
		gameController = gameControllerObject.GetComponent <gameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		gameController.addPower(power);
		gameController.addWater(water);
		gameController.addOxygen(oxygen);
		gameController.addFood(food);
		gameController.addMaterials(materials);
	}
}
