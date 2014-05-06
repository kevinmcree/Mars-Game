using UnityEngine;
using System.Collections;

public class buildingPlacer : MonoBehaviour {
	//public GameObject building;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
		Vector3 pos_move = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));
		transform.position = new Vector3(pos_move.x, pos_move.y, pos_move.z);
		
	}
	
	void OnMouseUp(){
		//Instantiate (this, this.transform.position, new Quaternion (0, 0, 0, 0));
		Destroy (this);
	}
}
