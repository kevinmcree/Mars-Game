using UnityEngine;
using System.Collections;

public class lifeSupport : abstractBuilding {

	public lifeSupport(){
		ResourcePerUpdate[ResourceType.Power] = -.02f;
		ResourcePerUpdate[ResourceType.Oxygen] = .02f;
	}

	override protected void Update(){
		//Run the base building update
		base.Update();

		//If life support building is not at max oxygen, set it to max and
		//remove the difference from the oxygen pool.
		if(currentOxygenVolume <= maxOxygenVolume){
			gameController.addResource(ResourceType.Oxygen, currentOxygenVolume-maxOxygenVolume);
			currentOxygenVolume = maxOxygenVolume;
		}
	}


}
