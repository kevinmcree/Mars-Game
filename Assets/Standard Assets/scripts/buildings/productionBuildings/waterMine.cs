using UnityEngine;
using System.Collections;

public class waterMine : productionBuilding {	
	protected override void Start(){
		base.Start();
		ResourcePerUpdate[ResourceType.Water] = .01f;
		ResourceRequiredPerUpdate[ResourceType.Power] = .02f;
		ResourceRequiredPerUpdate[ResourceType.Oxygen] = .001f;

		ResourceStorage[ResourceType.Water] = 10;
		ResourceStorage[ResourceType.Power] = 10;
		ResourceStorage[ResourceType.Oxygen] = 10;

		ResourceToBuild [ResourceType.Materials] = 50;
	}
}