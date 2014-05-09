using UnityEngine;
using System.Collections;

public class quarters : abstractBuilding {

	public float population = -.1f;

	public quarters(){
		ResourcePerUpdate[ResourceType.Oxygen] = -.01f;
		ResourcePerUpdate[ResourceType.Water] = -.01f;
		ResourcePerUpdate[ResourceType.Food] = -.01f;

		ResourceToBuild [ResourceType.Materials] = 100;
		ResourceToBuild[ResourceType.Oxygen] = 50;
	}
}
