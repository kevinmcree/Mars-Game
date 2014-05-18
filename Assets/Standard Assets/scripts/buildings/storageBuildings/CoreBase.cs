using UnityEngine;
using System.Collections;

//The initial building on Mars. Provides storage and the initial pool of resources.
//Rocket Drops dump into this building
public class CoreBase : storageBuilding {

	// Use this for initialization
	protected override void Start () {
		base.Start();
		this.isActive = true;
		ResourceStorage[ResourceType.Food] = 200;
		ResourceStorage[ResourceType.Materials] = 200;
		ResourceStorage[ResourceType.Oxygen] = 200;
		ResourceStorage[ResourceType.Population] = 5;
		ResourceStorage[ResourceType.Power] = 200;
		ResourceStorage[ResourceType.Water] = 200;

		addResource(ResourceType.Food, 200);
		addResource(ResourceType.Materials, 200);
		addResource(ResourceType.Oxygen, 200);
		addResource(ResourceType.Power, 5);
		addResource(ResourceType.Power, 200);
		addResource(ResourceType.Water, 200);
		addResource(ResourceType.Population, 5);
	}

	protected override void Update(){
		float pop = getResourceInStorage(ResourceType.Population);
		ResourceRequiredPerUpdate [ResourceType.Oxygen] = .004f * pop;
		ResourceRequiredPerUpdate [ResourceType.Water] = .004f * pop;
		ResourceRequiredPerUpdate [ResourceType.Food] = .001f * pop;
		base.Update();
	}
}
