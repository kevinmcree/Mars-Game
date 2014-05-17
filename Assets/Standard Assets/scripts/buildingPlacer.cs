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
		Vector3 pos_move = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.position = new Vector3(Mathf.Round(pos_move.x/gridSize)*gridSize,
		                                 Mathf.Round(pos_move.y/gridSize)*gridSize,
		                                 0);
		
	}
	
	void OnMouseUp(){
		//Instantiate (this, this.transform.position, new Quaternion (0, 0, 0, 0));
		GameObject.Find ("gameManager").GetComponent<gameManager> ().mouseHolding = false;
		gameObject.GetComponent<abstractBuilding> ().beginBuild ();
		Destroy (this);
	}
}
