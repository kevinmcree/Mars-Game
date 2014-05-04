using UnityEngine;
using System.Collections;

public class quarters : MonoBehaviour {

	public float oxygen;
	public float water;
	public float food;
	public float population;
	public float materials;
	private gameManager gameController;
	
	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.Find ("gameManager");
		gameController = gameControllerObject.GetComponent <gameManager>();
	}
	
	
	// Update is called once per frame
	void Update () {
		gameController.addPopulation(population);
		gameController.addFood(food);
		gameController.addOxygen(oxygen);
		gameController.addWater(water);
		gameController.addMaterials(materials);
		
	}
}
