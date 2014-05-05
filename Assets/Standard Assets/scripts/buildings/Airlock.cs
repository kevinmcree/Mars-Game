using UnityEngine;
using System.Collections;

public class Airlock : Corridor {

	private bool isopen = false;

	public bool isOpen { get { return isopen; } }

	public void setOpen(bool open) {
		isopen = open;
	}

}
