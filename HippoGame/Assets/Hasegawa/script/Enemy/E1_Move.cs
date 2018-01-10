using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_Move : MonoBehaviour {

	[SerializeField]float movespd = .2f;
	public float Speed{get{ return movespd;}set{ movespd = value;}}
	[SerializeField]byte nowlevel=1;
	[SerializeField]byte nowStatus = STATUS.IDLE;
	public byte Status{get{ return nowStatus;}set{ nowStatus = value;}}

	float initZ = 0;


	void Start () {
		
	}
	
	void Update () {
		
	}
}
