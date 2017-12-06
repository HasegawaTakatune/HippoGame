using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1_Move : MonoBehaviour {

	// 速度
	[SerializeField]float movespd = .2f;
	// Transform格納
	Transform trans;

	/// <summary>
	/// 初期化
	/// </summary>
	void Start () {
		trans = transform;
	}

	/// <summary>
	/// メインループ
	/// </summary>
	void Update () {
		Move ();
	}

	/// <summary>
	/// 左右移動
	/// </summary>
	void Move(){
		if (Input.GetKey (KeyCode.LeftArrow))
			trans.position -= trans.right * movespd;
		if (Input.GetKey (KeyCode.RightArrow))
			trans.position += trans.right * movespd;
	}
}
