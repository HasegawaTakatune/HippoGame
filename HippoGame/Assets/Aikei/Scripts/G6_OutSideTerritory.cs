using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class G6_OutSideTerritory : MonoBehaviour {
	
	[SerializeField]
	Text OSText;

//	E1_Move E1;

	[SerializeField]
	Transform goal;//スタートからゴールまでの距離

	[SerializeField]
	Transform PlayerTrans;

	[SerializeField]
	G1_GameManager GM;

	// Use this for initialization
	void Start () {
//		E1 = this.gameObject.GetComponent<E1_Move> ();

	}


	// Update is called once per frame
	void Update () {
		float range = Measure (PlayerTrans.position.z, goal.position.z);
		OSText.text="GOAL:"+range.ToString("f1")+"m";
		if (range <= 1) {
			Debug.Log ("GameClear");
			GM.GameTitle ();
		}
//		ShowDistance ();
	}
	/// <summary>
	/// 2つのゲームオブジェクトの距離を測る関数
	/// </summary>
	float Measure(float obj1,float obj2){
		return obj2-obj1;
	}
/*	void Measure(){
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
	}*/
}
