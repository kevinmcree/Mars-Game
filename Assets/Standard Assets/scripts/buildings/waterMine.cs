using UnityEngine;
using System.Collections;

public class waterMine : abstractBuilding {	
	public waterMine(){
		ResourcePerUpdate[ResourceType.Water] = .01f;
		ResourcePerUpdate[ResourceType.Power] = -.02f;
		ResourcePerUpdate[ResourceType.Oxygen] = -.001f;

		ResourceToBuild [ResourceType.Materials] = 50;
	}
}