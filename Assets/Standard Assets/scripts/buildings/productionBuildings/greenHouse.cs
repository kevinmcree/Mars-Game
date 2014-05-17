using UnityEngine;
using System.Collections;

public class greenHouse : productionBuilding {

	public float manpower = 0;

	protected override void Start(){
		base.Start();

		ResourceRequiredPerUpdate[ResourceType.Water] = .005f;
		ResourceRequiredPerUpdate[ResourceType.Power] = .005f;
		ResourcePerUpdate[ResourceType.Oxygen] = .005f;
		ResourcePerUpdate[ResourceType.Food] = .02f;

		ResourceStorage[ResourceType.Power] = 10;
		ResourceStorage[ResourceType.Water] = 10;
		ResourceStorage[ResourceType.Oxygen] = 10;
		ResourceStorage[ResourceType.Food] = 10;

		ResourceToBuild[ResourceType.Materials] = 50;
		//ResourceToBuild[ResourceType.Oxygen] = 50;

		constructionTime = 2;
	}
}
