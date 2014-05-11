using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * Base Building to inherit from. Adds no resources if somehow instantiated.
 */
public class abstractBuilding : MonoBehaviour {

	protected Dictionary<ResourceType, float> ResourcePerUpdate = new Dictionary<ResourceType, float>();
	protected Dictionary<ResourceType, float> ResourceToBuild = new Dictionary<ResourceType, float>();
	public float constructionTime = 0; //in seconds
	public float requiredPopulation = 0; //number of people needed for building to be active
	public float maxOxygenVolume = 0; //Units of Oxygen needed to fill a building when initially constructed or if a leak occurs
	public float currentOxygenVolume = 0;
	protected gameManager gameController;

	//Determines if building is actively producing resources
	private bool isactive = false;

	public bool isActive {
		get { return isActive; }
		set {
			Color col = gameObject.renderer.material.color;
			if (!value){
				Color hsva = ColorConverter.RGBAtoHSVA(col);
				hsva.b = .3f;
				col = ColorConverter.HSVAtoRGBA(hsva);
			} else {
				Color hsva = ColorConverter.RGBAtoHSVA(col);
				hsva.b = 1;
				col = ColorConverter.HSVAtoRGBA(hsva);
			}
			gameObject.renderer.material.color = col;
			isactive = value;
		}
	}

	// Use this for initialization
	protected virtual void Start() {
		//isActive = false;
		GameObject gameControllerObject = GameObject.Find("gameManager");
		gameController = gameControllerObject.GetComponent <gameManager>();
	}
	
	// Update is called once per frame
	protected virtual void Update() {
		//BEGIN add resources to pool if active
		if (isactive) {
			foreach (KeyValuePair<ResourceType, float> ent in ResourcePerUpdate) {
				gameController.addResource(ent.Key, ent.Value);
			}
		}
		//END add resources to pool if active
	}

	public Dictionary<ResourceType, float> RequiredResources() {
		return ResourceToBuild;
	}
}
