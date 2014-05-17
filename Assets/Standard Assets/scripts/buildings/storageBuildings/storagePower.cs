using UnityEngine;
using System.Collections;

public class storagePower : storageBuilding {

	protected override void Start(){
		base.Start();
		ResourceStorage[ResourceType.Power] = 100;

		ResourceToBuild [ResourceType.Materials] = 100;
	}
}

