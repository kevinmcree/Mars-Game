using UnityEngine;
using System.Collections;

public class powerPlant : abstractBuilding {	
	public powerPlant(){
		ResourcePerUpdate[ResourceType.Power] = .01f;
	}
}