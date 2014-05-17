using UnityEngine;
using System.Collections;

public class powerPlant : productionBuilding {
	protected override void Start(){
		base.Start();

		ResourcePerUpdate[ResourceType.Power] = .01f;
		
		ResourceToBuild [ResourceType.Materials] = 50;
		ResourceToBuild[ResourceType.Oxygen] = 25;
		
		ResourceStorage [ResourceType.Power] = 10;

		constructionTime = 2;
	}
}