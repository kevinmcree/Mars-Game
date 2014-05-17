using UnityEngine;
using System.Collections;

public class storageMaterials : storageBuilding {

	protected override void Start(){
		base.Start();
		ResourceStorage[ResourceType.Materials] = 100;

		ResourceToBuild [ResourceType.Materials] = 100;
	}
}

