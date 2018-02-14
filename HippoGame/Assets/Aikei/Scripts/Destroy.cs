using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke("Des",15.0f);
	}
	void Des(){
		Destroy (this.gameObject);
	}
}
