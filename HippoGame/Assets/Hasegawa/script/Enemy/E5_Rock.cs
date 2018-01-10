using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E5_Rock : MonoBehaviour {

	E1_Move move;
	GameObject _camera;
	[SerializeField]float Shake_x = .3f,Shake_y = .3f,Shake_Time = .5f;

	void Start () {
		move = GetComponent<E1_Move> ();
		_camera = GameObject.FindGameObjectWithTag ("Camera");
	}

	void Rock(){
		move.Status = STATUS.IDLE;
	}

	void Shake(){
		iTween.ShakePosition (_camera, iTween.Hash ("x", Shake_x, "y", Shake_y, "time", Shake_Time));
	}
	
	void OnCollisionEnter(Collision collision){
		if (collision.transform.tag == "Rock") {
			Rock ();
			Shake ();
			Destroy (collision.gameObject);
		}
	}
}
