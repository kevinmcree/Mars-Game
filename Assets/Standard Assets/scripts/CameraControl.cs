using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	Vector3 old_pos = Vector3.zero;
	
	// Update is called once per frame
	void Update() {
		//gets current camera size
		float cameraSize = this.GetComponent<Camera>().orthographicSize;
		//if right mousebutton is pressed
		if (Input.GetMouseButton(1)) {
			//get mouse position
			Vector3 new_pos = Input.mousePosition;
			//get ratio of current screen resolution to internal camera resolution
			float ratio = Screen.height/(cameraSize*2);
			//scale mouse position to internal position
			new_pos /= ratio;
			//if old position is zeroed out, set it to current position
			if(old_pos == Vector3.zero){old_pos = new_pos;}
			//calculate the change in position
			Vector3 delta = new_pos - old_pos;
			//move the camera
			transform.position = transform.position-delta;
			//set the old position to the current position
			old_pos = new_pos;
		} else {
			//if the right mouse is not clicked, zero out the old position
			old_pos = Vector3.zero;
		}
		//zoom in/out with mouse wheel
		float newSize = Mathf.Clamp(cameraSize - Input.GetAxis("Mouse ScrollWheel")*60, 100, 400);
		this.GetComponent<Camera>().orthographicSize = newSize;
	}
}
