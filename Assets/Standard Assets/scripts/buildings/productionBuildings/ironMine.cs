using UnityEngine;
using System.Collections;

public class ironMine : productionBuilding {	
	protected override void Start(){
		base.Start();
		ResourcePerUpdate[ResourceType.Materials] = .01f;
		ResourceRequiredPerUpdate[ResourceType.Power] = .02f;
		ResourceRequiredPerUpdate[ResourceType.Oxygen] = .001f;

		ResourceStorage[ResourceType.Materials] = 10;
		ResourceStorage[ResourceType.Power] = 10;
		ResourceStorage[ResourceType.Oxygen] = 10;
		
		ResourceToBuild [ResourceType.Materials] = 25;
	}
}
