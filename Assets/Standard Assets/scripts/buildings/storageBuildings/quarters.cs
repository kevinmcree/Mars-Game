using UnityEngine;
using System.Collections;

public class quarters : storageBuilding {

	public float population = -.1f;

	protected override void Start(){
		base.Start();
		ResourceRequiredPerUpdate[ResourceType.Oxygen] = .004f;
		ResourceRequiredPerUpdate[ResourceType.Water] = .004f;
		ResourceRequiredPerUpdate[ResourceType.Food] = .001f;

		ResourceStorage[ResourceType.Oxygen] = 10;
		ResourceStorage[ResourceType.Water] = 10;
		ResourceStorage[ResourceType.Food] = 10;

		ResourceStorage[ResourceType.Population] = 5;

		ResourceToBuild [ResourceType.Materials] = 100;
		ResourceToBuild[ResourceType.Oxygen] = 50;
	}

	protected override void Update(){
		float pop = getResourceInStorage(ResourceType.Population);
		ResourceRequiredPerUpdate[ResourceType.Oxygen] = .004f * pop;
		ResourceRequiredPerUpdate[ResourceType.Water] = .004f * pop;
		ResourceRequiredPerUpdate[ResourceType.Food] = .001f * pop;
		base.Update();
	}
}
