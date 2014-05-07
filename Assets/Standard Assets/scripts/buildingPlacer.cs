using UnityEngine;
using System.Collections;

public class buildingPlacer : MonoBehaviour {
	//public GameObject building;
	public int gridSize = 20;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
		Vector3 pos_move = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));
		transform.position = new Vector3(Mathf.Round(pos_move.x/gridSize)*gridSize,
		                                 Mathf.Round(pos_move.y/gridSize)*gridSize,
		                                 Mathf.Round(pos_move.z/gridSize)*gridSize);
		
	}
	
	void OnMouseUp(){
		//Instantiate (this, this.transform.position, new Quaternion (0, 0, 0, 0));

		Destroy (this);
	}
}
