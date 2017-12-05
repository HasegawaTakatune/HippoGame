using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P3_Puddle : MonoBehaviour {

	// スリップ速度
	public float slidespd = .1f;
	// Transform格納
	Transform trans;

	/// <summary>
	/// 初期化
	/// </summary>
	void Start () {
		trans = transform;
	}

	/// <summary>
	/// スリップ処理
	/// </summary>
	void Puddle(){
		trans.position -= trans.forward * slidespd;
	}

	/// <summary>
	/// 当たり判定（触れ続けている有効）
	/// </summary>
	void OnTriggerStay(Collider collider){
		string tag = collider.gameObject.tag;
		if (tag == "Puddle" || tag == "Sweat")
			Puddle ();
	}

}
