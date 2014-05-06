using UnityEngine;
using System.Collections;

public class Corridor : abstractBuilding {
	
	public Corridor(){
		ResourceToBuild [ResourceType.Materials] = 25;

		maxOxygenVolume = 1;
		manHours = 5;
	}
}
