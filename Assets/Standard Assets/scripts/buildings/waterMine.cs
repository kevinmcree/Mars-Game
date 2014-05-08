using UnityEngine;
using System.Collections;

public class waterMine : abstractBuilding {	
	public waterMine(){
		ResourcePerUpdate[ResourceType.Water] = .01f;
		ResourcePerUpdate[ResourceType.Power] = -.01f;

		ResourceToBuild [ResourceType.Materials] = 50;
	}
}