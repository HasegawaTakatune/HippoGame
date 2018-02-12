using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTest : MonoBehaviour {
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.R)) {
			Raycast ();
		}
	}
	RaycastHit hit;
	void Raycast(){
		if (Physics.Raycast (transform.position, transform.forward,out hit, 10.0f)) {
			Debug.Log (hit.transform.name);
		}
	}
}
