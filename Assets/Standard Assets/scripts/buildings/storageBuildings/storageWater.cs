using UnityEngine;
using System.Collections;

public class storageWater : storageBuilding {

	protected override void Start(){
		base.Start();
		ResourceStorage[ResourceType.Water] = 100;

		ResourceToBuild [ResourceType.Materials] = 100;
	}
}

