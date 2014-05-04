using UnityEngine;
using System.Collections;

public class greenHouse : MonoBehaviour {
	public float power;
	public float water;
	public float oxygen;
	public float food;
	public float manpower;
	public float materials;
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
