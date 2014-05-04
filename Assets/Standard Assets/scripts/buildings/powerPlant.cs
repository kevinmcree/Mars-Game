using UnityEngine;
using System.Collections;

public class powerPlant : MonoBehaviour {
	public float materials;
	public float power;
	private gameManager gameController;
	
	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.Find ("gameManager");
		gameController = gameControllerObject.GetComponent <gameManager>();
	}

	
	// Update is called once per frame
	void Update () {
		gameController.addPower(power);
		gameController.addMaterials(materials);
	
	}
}
