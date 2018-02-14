using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G7_Slide : MonoBehaviour {


	float slidespd=0;	//このオブジェクトのスライド量を保存する
	Transform trans;	//使うTransformを保存する変数宣言
	G1_GameManager GM;	//使うゲームマネージャを保存する変数宣言

	[SerializeField]
	bool loopflg=false;
	[SerializeField]
	Transform loopZobject;	//ループするオブジェクトのスケールを取得

	float initpos;		//このオブジェクトの初期座標
	float loopshiftpos;	//ループされた座標
	[SerializeField]
	byte loopobjcts;	//ループするオブジェクト数
	// Use this for initialization
	void Start () {
		//このオブジェクトのスライド速度をGameManagerから参照する
		slidespd=GameObject.FindGameObjectWithTag("GameManager").GetComponent<G1_GameManager> ().GetSlideSpd;

		//このオブジェクトのTransformを格納する
		trans = this.gameObject.transform;

		if (loopZobject != null) {
			initpos = loopZobject.position.z;
			if (initpos < 0)
				initpos *= -1;
			loopshiftpos = initpos * loopZobject.localScale.z / 10;
		}
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
		if (loopflg == true) Loop ();
	}
	/// <summary>
	/// オブジェクトをループする関数
	/// </summary>
	void Loop(){
		//現在の座標　よりも　初期座標ーループ後の座標が大きいならば
		if (trans.position.z <= -initpos-loopshiftpos) {
			Debug.Log (trans.name+":loop");
			trans.position += new Vector3 (0, 0, loopshiftpos*loopobjcts);
		}

	}
}
