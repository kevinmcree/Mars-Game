using UnityEngine;
using System.Collections;

public class storageOxygen : storageBuilding {

	protected override void Start(){
		base.Start();
		ResourceStorage[ResourceType.Oxygen] = 100;

		ResourceToBuild [ResourceType.Materials] = 100;
	}
}

