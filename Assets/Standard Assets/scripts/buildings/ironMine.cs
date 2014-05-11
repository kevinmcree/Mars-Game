using UnityEngine;
using System.Collections;

public class ironMine : abstractBuilding {	
	public ironMine(){
		ResourcePerUpdate[ResourceType.Materials] = .01f;
		ResourcePerUpdate[ResourceType.Power] = -.02f;
		ResourcePerUpdate[ResourceType.Oxygen] = -.001f;
		
		ResourceToBuild [ResourceType.Materials] = 25;
	}
}
