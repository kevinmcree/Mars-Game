using UnityEngine;
using System.Collections;

public class abstractBuilding : MonoBehaviour {

	public float power = 0; //Units of Power produced per update
	public float water = 0; //Units of Water produced per update
	public float oxygen = 0; //Units of Oxygen produced per update
	public float food = 0; //Units of Food produced per update
	public float materials = 0; //Units of Building Materials produced per update

	public float materialsToBuild = 0; //Units of Materials required/consumed to build
	public float manHours = 0; //Man hours needed to construct the building
	public float oxygenVolume = 0; //Units of Oxygen needed to fill a building when initially constructed or if a leak occurs

	private gameManager gameController;

	// Use this for initialization
	protected virtual void Start () {
		GameObject gameControllerObject = GameObject.Find ("gameManager");
		gameController = gameControllerObject.GetComponent <gameManager>();
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		//BEGIN add resources to pool
		gameController.addPower(power);
		gameController.addWater(water);
		gameController.addOxygen(oxygen);
		gameController.addFood(food);
		gameController.addMaterials(materials);
		//END add resources to pool
	}
}
