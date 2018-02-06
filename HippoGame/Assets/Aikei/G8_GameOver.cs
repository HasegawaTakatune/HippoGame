using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G8_GameOver : MonoBehaviour {
	G1_GameManager GM;

	// Use this for initialization
	void Start () {
		GM = GameObject.Find ("GameManager").GetComponent<G1_GameManager> ();
	}
	void OnCollisionEnter(Collision col){
		if (col.transform.tag == "Enemy") {
			GM.GameTitle ();
		}
	}
}
