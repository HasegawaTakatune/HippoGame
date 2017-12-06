using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2_Jump : MonoBehaviour {

	// ジャンプ速度
	[SerializeField] float jumpspd = 1;
	// ジャンプ高さ
	[SerializeField] float jumpheight = 1;
	// 天井
	float ceiling;
	// ジャンプ中判定
	bool isjump = false;
	// Transform格納
	Transform trans;
	// 上昇・下降の関数を格納
	System.Action action;

	/// <summary>
	/// 初期化
	/// </summary>
	void Start () {
		trans = transform;
		ceiling = trans.position.y + jumpheight;
		action = () => Up ();
	}

	/// <summary>
	/// メインループ
	/// </summary>
	void Update () {
		Jump ();
	}

	/// <summary>
	/// ジャンプ
	/// </summary>
	void Jump(){
		// キー入力
		if (Input.GetKey (KeyCode.Space)&& !isjump) {
			isjump = true;
		}
		// 上昇・下降の処理をする
		if (isjump)
			action ();
	}

	/// <summary>
	/// 上昇
	/// </summary>
	void Up(){
		// 上昇
		trans.position += trans.up * jumpspd;
		// 上昇限界処理
		if (trans.position.y >= ceiling)
			action = () => Down();
	}

	/// <summary>
	/// 下降
	/// </summary>
	void Down(){
		// 下降
		trans.position -= trans.up * jumpspd;
		// 着地処理
		if (trans.position.y <= ceiling - jumpheight) {
			isjump = false;
			action = () => Up ();
		}
	}
}
