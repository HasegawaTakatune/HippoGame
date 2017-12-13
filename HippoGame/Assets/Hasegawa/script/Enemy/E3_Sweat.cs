using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E3_Sweat : MonoBehaviour {

	E1_Move move;
	Transform trns;

	[SerializeField]string resource = "Sweat";

	void Start () {
		move = GetComponent<E1_Move> ();
		trns = transform;
		StartCoroutine (Sweat ());
	}

	IEnumerator Sweat(){
		GameObject _resource = Resources.Load (resource, typeof(GameObject))as GameObject;
		while (true) {
			yield return new WaitForSeconds (10);
			Instantiate (_resource, trns.position,Quaternion.identity).GetComponent<Rigidbody> ().AddForce (trns.forward);
		}
	}
}
