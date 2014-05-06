using UnityEngine;
using System.Collections;

public class quarters : abstractBuilding {

	public float population = -.1f;

	public quarters(){
		ResourcePerUpdate[ResourceType.Oxygen] = -.005f;
		ResourcePerUpdate[ResourceType.Water] = -.005f;
		ResourcePerUpdate[ResourceType.Food] = -.005f;

		ResourceToBuild [ResourceType.Materials] = 100;
	}
}
