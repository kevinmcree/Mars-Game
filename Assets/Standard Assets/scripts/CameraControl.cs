using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	Vector3 old_pos = Vector3.zero;

	// Use this for initialization
	void Start() {
	
	}
	
	// Update is called once per frame
	void Update() {
		float cameraSize = this.GetComponent<Camera>().orthographicSize;
		if (Input.GetMouseButton(1)) {
			Vector3 new_pos = Input.mousePosition;
			float ratio = Screen.height/(cameraSize*2);
			new_pos /= ratio;
			if(old_pos == Vector3.zero){old_pos = new_pos;}
			Vector3 delta = new_pos - old_pos;
			print(Screen.height + " " + Screen.width);

			transform.position = transform.position-delta;
			old_pos = new_pos;
		} else {
			old_pos = Vector3.zero;
		}
		float newSize = Mathf.Clamp(cameraSize - Input.GetAxis("Mouse ScrollWheel")*60, 100, 400);
		this.GetComponent<Camera>().orthographicSize = newSize;
	}
}
