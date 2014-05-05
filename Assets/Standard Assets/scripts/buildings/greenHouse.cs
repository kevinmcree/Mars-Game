using UnityEngine;
using System.Collections;

public class greenHouse : abstractBuilding {

	public float manpower = 0;

	public greenHouse(){
		ResourcePerUpdate[ResourceType.Power] = .005f;
		ResourcePerUpdate[ResourceType.Water] = .005f;
		ResourcePerUpdate[ResourceType.Oxygen] = .005f;
		ResourcePerUpdate[ResourceType.Food] = .01f;
	}
}
