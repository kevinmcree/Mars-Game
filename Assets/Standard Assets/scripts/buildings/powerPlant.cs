using UnityEngine;
using System.Collections;

public class powerPlant : abstractBuilding {	
	public powerPlant(){
		ResourcePerUpdate[ResourceType.Power] = .01f;

		ResourceToBuild [ResourceType.Materials] = 50;
		ResourceToBuild[ResourceType.Oxygen] = 25;
	}
}