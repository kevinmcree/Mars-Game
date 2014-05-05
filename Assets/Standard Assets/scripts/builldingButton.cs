using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class builldingButton : MonoBehaviour {

	Dictionary<ResourceType, float> ResourcesConsumed = new Dictionary<ResourceType, float>();
	
	public float power { get { return ResourcesConsumed[ResourceType.Power]; } set { ResourcesConsumed[ResourceType.Power] = value; } }

	public float water{ get { return ResourcesConsumed[ResourceType.Water]; } set { ResourcesConsumed[ResourceType.Water] = value; } }

	public float oxygen{ get { return ResourcesConsumed[ResourceType.Oxygen]; } set { ResourcesConsumed[ResourceType.Oxygen] = value; } }

	public float food{ get { return ResourcesConsumed[ResourceType.Food]; } set { ResourcesConsumed[ResourceType.Food] = value; } }

	public float population{ get { return ResourcesConsumed[ResourceType.Population]; } set { ResourcesConsumed[ResourceType.Population] = value; } }

	public float materials{ get { return ResourcesConsumed[ResourceType.Materials]; } set { ResourcesConsumed[ResourceType.Materials] = value; } }
	
	public GameObject building;
	private gameManager gameController;

	// Use this for initialization
	void Start() {
		GameObject gameControllerObject = GameObject.Find("gameManager");
		gameController = gameControllerObject.GetComponent <gameManager>();
	}
	
	// Update is called once per frame
	void Update() {
	
	}

	void OnMouseUp() {
		if (gameController.resourcePool[ResourceType.Materials] >= materials) {
			Instantiate(building, this.transform.position, new Quaternion(0, 0, 0, 0));
			foreach (KeyValuePair<ResourceType, float> ent in ResourcesConsumed) {
				gameController.addResource(ent.Key, ent.Value);
			}


		}
	}
}
