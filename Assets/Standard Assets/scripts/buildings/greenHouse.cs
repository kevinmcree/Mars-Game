using UnityEngine;
using System.Collections;

public class greenHouse : abstractBuilding {

	public float manpower = 0;

	public greenHouse(){
		power = -.005f;
		water = -.005f;
		oxygen = .005f;
		food = .01f;
	}
}
