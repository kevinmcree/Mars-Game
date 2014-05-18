using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

//Base Building to inherit from.
public class abstractBuilding : MonoBehaviour
{

	public Dictionary<ResourceType, float> ResourcePerUpdate = new Dictionary<ResourceType, float>();
	public Dictionary<ResourceType, float> ResourceRequiredPerUpdate = new Dictionary<ResourceType, float>();
	public Dictionary<ResourceType, float> ResourceToBuild = new Dictionary<ResourceType, float>();
	public Dictionary<ResourceType, float> ResourceStorage = new Dictionary<ResourceType, float>();
	public Dictionary<ResourceType, float> ResourceInStorage = new Dictionary<ResourceType, float>();
	public float constructionTime = 2; //in seconds
	public float elapsedConstructionTime = 0; //in seconds
	public float requiredPopulation = 0; //number of people needed for building to be active
	public float maxOxygenVolume = 0; //Units of Oxygen needed to fill a building when initially constructed or if a leak occurs
	public float currentOxygenVolume = 0;
	protected gameManager gameController;
	private int waittobuild = 0;

	//Determines if building is actively producing resources
	private bool isactive = false;

	public bool isActive {
		get { return isactive; }
		set {
			isactive = value;
			Color col = gameObject.renderer.material.color;
			//If inactive,
			if(!isactive) {
				//Set the color tint to be darker
				Color hsva = ColorConverter.RGBAtoHSVA(col);
				hsva.b = .3f;
				col = ColorConverter.HSVAtoRGBA(hsva);
				//If active
			} else {
				//ensure the color tint is the original
				Color hsva = ColorConverter.RGBAtoHSVA(col);
				hsva.b = 1;
				col = ColorConverter.HSVAtoRGBA(hsva);
			}
			gameObject.renderer.material.color = col;
		}
	}

	// Use this for initialization
	protected virtual void Start()
	{
		constructionTime = 2;
		isActive = false;
		StartCoroutine("checkResources");
		GameObject gameControllerObject = GameObject.Find("gameManager");
		gameController = gameControllerObject.GetComponent <gameManager>();
	}
	
	// Update is called once per frame
	protected virtual void Update()
	{
		//If building is not active, ignore everything
		if(!isactive) {
			return;
		}
		//Check if the required resources are in storage
		//jack out if not
		foreach(KeyValuePair<ResourceType, float> ent in ResourceRequiredPerUpdate) {
			if(ent.Value > getResourceInStorage(ent.Key)) {
				return;
			}
		}
		//remove the resources required
		foreach(KeyValuePair<ResourceType, float> ent in ResourceRequiredPerUpdate) {
			addResource(ent.Key, -ent.Value);
		}
		//add the resources produced
		foreach(KeyValuePair<ResourceType, float> ent in ResourcePerUpdate) {
			addResource(ent.Key, ent.Value);
		}
	}

	//helper function to simplify access to build();
	public void beginBuild()
	{
		StartCoroutine("build");
	}

	//begins the build process
	public IEnumerator build()
	{
		//for each type of required resource
		foreach(KeyValuePair<ResourceType, float> ent in ResourceToBuild) {
			//drain from the closest storage building
			StartCoroutine("requestBuildingResources", ent);
		}

		//waint until all the required resources have been drained
		while(waittobuild>0) {
			yield return new WaitForSeconds(.1f);
		}


		while(elapsedConstructionTime < constructionTime) {
			//add the delta
			elapsedConstructionTime += Time.deltaTime;

			//color slowly brightens over time up to .8 original lightness
			//snaps to 1.0 after becoming active to make the transition more obvious
			Color col = gameObject.renderer.material.color;
			Color hsva = ColorConverter.RGBAtoHSVA(col);
			hsva.b = (elapsedConstructionTime / constructionTime * .5f) + .3f;
			col = ColorConverter.HSVAtoRGBA(hsva);
			gameObject.renderer.material.color = col;
			yield return null;
		}
		isActive = true;
	}

	//Drains the resources required from the nearest storage buildings
	public IEnumerator requestBuildingResources(KeyValuePair<ResourceType, float> ent)
	{
		//tick up the counter indicating a resource is in the process of being drained
		waittobuild++;
		//grab all storage buildings
		storageBuilding[] objs = (storageBuilding[])GameObject.FindObjectsOfType(typeof(storageBuilding));
		//get their distances from this building
		float[] dists = new float[objs.Length];
		for(int i = 0; i < objs.Length; ++i) {
			dists[i] = Vector3.Distance(this.transform.position, objs[i].transform.position);
		}
		//sort based on distances
		Array.Sort(dists, objs);
		int resourceTaken = 0;
		while(resourceTaken < ent.Value) {
			//grab a resource every .05 seconds
			foreach(storageBuilding build in objs) {
				if(build.getResourceInStorage(ent.Key) < 1){continue;}
				build.addResource(ent.Key, -1);
				addResource(ent.Key, 1);
				resourceTaken++;
				break;
			}
			yield return new WaitForSeconds(.05f);
		}
		//tick down the counter to indicate the routine is finished
		waittobuild--;
	}

	//Drains the resources required from the nearest storage buildings
	public IEnumerator requestResources(KeyValuePair<ResourceType, float> ent)
	{
		//grab all storage buildings
		storageBuilding[] objs = (storageBuilding[])GameObject.FindObjectsOfType(typeof(storageBuilding));
		//get their distances from this building
		float[] dists = new float[objs.Length];
		for(int i = 0; i < objs.Length; ++i) {
			dists[i] = Vector3.Distance(this.transform.position, objs[i].transform.position);
		}
		//sort based on distances
		Array.Sort(dists, objs);
		int resourceTaken = 0;
		while(resourceTaken < ent.Value) {
			//grab a resource every .05 seconds
			foreach(storageBuilding build in objs) {
				if(build.getResourceInStorage(ent.Key) < 1){continue;}
				build.addResource(ent.Key, -1);
				addResource(ent.Key, 1);
				resourceTaken++;
				break;
			}
			yield return new WaitForSeconds(.05f);
		}
	}

	//Pushes the resources to the nearest storage buildings
	public IEnumerator pushResources(KeyValuePair<ResourceType, float> ent)
	{
		//grab all storage buildings
		storageBuilding[] objs = (storageBuilding[])GameObject.FindObjectsOfType(typeof(storageBuilding));
		//get their distances from this building
		float[] dists = new float[objs.Length];
		for(int i = 0; i < objs.Length; ++i) {
			dists[i] = Vector3.Distance(this.transform.position, objs[i].transform.position);
		}
		//sort based on distances
		Array.Sort(dists, objs);
		int resourcePushed = 0;
		while(resourcePushed < ent.Value) {
			//push a resource every .05 seconds
			foreach(storageBuilding build in objs) {
				if(build.getResourceStorage(ent.Key) < 1 || !build.isActive || build.Equals(this)){continue;}
				if(build.getResourceInStorage(ent.Key) > build.getResourceStorage(ent.Key)-1){
					continue;}
				build.addResource(ent.Key, 1);
				addResource(ent.Key, -1);
				resourcePushed++;
				break;
			}
			yield return new WaitForSeconds(.05f);
		}
	}

	public IEnumerator checkResources(){
		while(true) {
			if (!isactive){
				yield return new WaitForSeconds(.1f);
			}
			//For each kind of resources required
			foreach(KeyValuePair<ResourceType, float> ent in ResourceRequiredPerUpdate) {
				//If the resource is under 20%
				if(getResourceInStorage(ent.Key) / getResourceStorage(ent.Key) < .2) {
					//Request 50% of storage from storage buildings
					StartCoroutine("requestResources",
			               new KeyValuePair<ResourceType, float>
			               (ent.Key, Mathf.Round(getResourceStorage(ent.Key) * .5f)));
				}
			}

			//for each kind of resource required
			foreach(KeyValuePair<ResourceType, float> ent in ResourcePerUpdate) {
				//If stored resource is over 80%
				if(getResourceInStorage(ent.Key) / getResourceStorage(ent.Key) > .8) {
					//Push them all to storage buildings
					StartCoroutine("pushResources",
			               new KeyValuePair<ResourceType, float>
			               (ent.Key, Mathf.Floor(getResourceInStorage(ent.Key))));
				}
			}
			yield return new WaitForSeconds(.1f);
		}
	}


	//adds a resources to storage
	public void addResource(ResourceType res, float value)
	{
		if(ResourceInStorage.ContainsKey(res)) {
			ResourceInStorage[res] = Mathf.Clamp(ResourceInStorage[res] + value, 0, getResourceStorage(res));
		} else {
			ResourceInStorage.Add(res, value);
		}
	}

	//BEGIN Getters for specific resources from specific dictionaries
	//ensures a 0 return if the dictionary has no value for the resource type
	public float getResourcePerUpdate(ResourceType res)
	{
		if(ResourcePerUpdate.ContainsKey(res)) {
			return ResourcePerUpdate[res];
		} else {
			return 0;
		}
	}

	public float getResourceRequiredPerUpdate(ResourceType res)
	{
		if(ResourceRequiredPerUpdate.ContainsKey(res)) {
			return ResourceRequiredPerUpdate[res];
		} else {
			return 0;
		}
	}

	public float getResourceToBuild(ResourceType res)
	{
		if(ResourceToBuild.ContainsKey(res)) {
			return ResourceToBuild[res];
		} else {
			return 0;
		}
	}

	public float getResourceStorage(ResourceType res)
	{
		if(ResourceStorage.ContainsKey(res)) {
			return ResourceStorage[res];
		} else {
			return 0;
		}
	}

	public float getResourceInStorage(ResourceType res)
	{
		if(ResourceInStorage.ContainsKey(res)) {
			return ResourceInStorage[res];
		} else {
			return 0;
		}
	}
	//END Getters for specific resources from specific dictionaries
}
