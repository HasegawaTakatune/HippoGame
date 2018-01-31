using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class G6_OutSideTerritory : MonoBehaviour {

	[SerializeField]
	Text OSText;

	E1_Move E1;

	float goal;//スタートからゴールまでの距離
	// Use this for initialization
	void Start () {
		E1 = this.gameObject.GetComponent<E1_Move> ();
	}
	
	// Update is called once per frame
	void Update () {
		Measure ();
		ShowDistance ();
	}
	void Measure(){
		switch (E1.nowlevel) {
		case 1:
			if (Distance () >= goal) {
			}
			break;
		case 2:
			break;
		case 3:
			break;
		default:
			Debug.Log ("値が不正です" + E1.nowlevel);
			break;
		}
	}
	float Distance(){
	}
	void ShowDistance(){
	}
}
