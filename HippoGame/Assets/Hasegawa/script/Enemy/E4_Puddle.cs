using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E4_Puddle : MonoBehaviour {

	[SerializeField] float puddlespd = .2f;
	E1_Move move;

	void Start () {
		move = GetComponent<E1_Move> ();
	}

	void OnTriggerEnter(Collider collider){
		if (collider.tag == "Puddle")
			Puddle (true);
	}

	void OnTriggerExit(Collider collider){
		if (collider.tag == "Puddle")
			Puddle (false);
	}

	void Puddle(bool flg){
		move.Speed += (flg) ? puddlespd : -puddlespd;
	}
}
