using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour {
	public float power;
	public float water;
	public float oxygen;
	public float food;
	public float population;
	public float materials;

	public GUIText powerText;
	public GUIText waterText;
	public GUIText oxygenText;
	public GUIText foodText;
	public GUIText populationText;
	public GUIText materialsText;


	// Use this for initialization
	void Start () {
		updatePower ();
		updateWater ();
		updateOxygen ();	
		updateFood ();
		updatePopulation ();
		updateMaterials ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	//these statements are all called by other functions to update the values held in the controller
	public void addPower (float newPowerValue)
	{
		power += newPowerValue;
		updatePower ();
	}
	void updatePower ()
	{
		powerText.text = "Power: " + power.ToString ("0");
	}

	public void addWater (float newWaterValue)
	{
		water += newWaterValue;
		updateWater ();
	}
	void updateWater ()
	{
		waterText.text = "Water: " + water.ToString ("0");
	}

	public void addOxygen (float newOxygenValue)
	{
		oxygen += newOxygenValue;
		updateOxygen ();
	}
	
	void updateOxygen ()
	{
		oxygenText.text = "Oxygen: " + oxygen.ToString ("0");
	}

	public void addFood (float newFoodValue)
	{
		food += newFoodValue;
		updateFood ();
	}
	void updateFood ()
	{
		foodText.text = "Food: " + food.ToString ("0");
	}

	public void addPopulation (float newPopulationValue)
	{
		population += newPopulationValue;
		updatePopulation ();
	}
	void updatePopulation ()
	{
		populationText.text = "Population: " + population.ToString ("0");
	}

	public void addMaterials (float newMaterialsValue)
	{
		materials += newMaterialsValue;
		updateMaterials ();
	}
	void updateMaterials ()
	{
		materialsText.text = "Materials: " + materials.ToString ("0");
	}

}
