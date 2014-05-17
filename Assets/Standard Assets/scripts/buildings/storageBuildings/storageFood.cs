using UnityEngine;
using System.Collections;

public class storageFood : storageBuilding {

	protected override void Start(){
		base.Start();
		ResourceStorage[ResourceType.Food] = 100;

		ResourceToBuild [ResourceType.Materials] = 100;
	}
}

