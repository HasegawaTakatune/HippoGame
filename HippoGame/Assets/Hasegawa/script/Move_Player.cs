using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Player : MonoBehaviour {

	[SerializeField]float speed = 0.1f;
	Transform myTransform;
	void Start () {
		myTransform = transform;
	}
	
	void Update () {
		if (Input.GetKey (KeyCode.LeftArrow))
			myTransform.position -= myTransform.right * speed;

		if (Input.GetKey (KeyCode.RightArrow))
			myTransform.position += myTransform.right * speed;
	}
}
