using UnityEngine;
using System.Collections;

public class builldingButton : MonoBehaviour {
	public float power;
	public float water;
	public float oxygen;
	public float food;
	public float population;
	public float materials;
	
	public GameObject building;
	private gameManager gameController;

	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.Find ("gameManager");
		gameController = gameControllerObject.GetComponent <gameManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp(){
		if (gameController.power>=power &&
		    gameController.water>=water &&
		    gameController.oxygen>=oxygen &&
		    gameController.food>=food &&
		    gameController.population>=population &&
		    gameController.materials>=materials){
			Instantiate (building, this.transform.position, new Quaternion (0, 0, 0, 0));
			gameController.addPower(power);
			gameController.addWater(water);
			gameController.addOxygen(oxygen);
			gameController.addFood(food);
			gameController.addPopulation(population);
			gameController.addMaterials(materials);



		}
	}
}
