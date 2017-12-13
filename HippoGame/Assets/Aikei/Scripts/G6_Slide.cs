using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G6_Slide : MonoBehaviour {


	float slidespd=0;	//このオブジェクトのスライド量を保存する
	Transform trans;	//使うTransformを保存する変数宣言
	G1_GameManager GM;	//使うゲームマネージャを保存する変数宣言

	// Use this for initialization
	void Start () {
		//このオブジェクトのスライド速度をGameManagerから参照する
		slidespd=GameObject.Find("GameManager").GetComponent<G1_GameManager> ().GetSlideSpd;

		//このオブジェクトのTransformを格納する
		trans = this.gameObject.transform;
	}
	
	// Update is called once per frame
	void Update () {
		Slide();
	}

	/// <summary>
	/// スライド移動をする関数
	/// </summary>
	void Slide(){
		trans.position -= new Vector3 (0, 0, slidespd);
	}
}
