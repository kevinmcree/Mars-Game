using UnityEngine;
using System.Collections;

public class lifeSupport : productionBuilding {

	protected override void Start(){
		base.Start();
		ResourceRequiredPerUpdate[ResourceType.Power] = .02f;
		ResourcePerUpdate[ResourceType.Oxygen] = .02f;

		ResourceStorage[ResourceType.Power] = 10;
		ResourceStorage[ResourceType.Oxygen] = 10;

		ResourceToBuild [ResourceType.Materials] = 100;
	}
}
