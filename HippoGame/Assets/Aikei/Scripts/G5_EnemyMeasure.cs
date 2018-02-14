using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class G5_EnemyMeasure : MonoBehaviour {
	[SerializeField]
	Scrollbar EMScrollber;	//距離を表示するGUI

	[SerializeField]
	Text EMText;		//距離を表示するテキスト

	GameObject Player;	//プレイヤーのゲームオブジェクト
	Transform PlayerTrans;	//プレイヤーの座標群
	GameObject Enemy;	//敵のゲームオブジェクト
	Transform EnemyTrans;	//敵の座標群

	[SerializeField]
	short MeasureLimit=100;	//最大距離

	void Start(){
		//ゲームオブジェクトの検索,格納
		Player = GameObject.FindGameObjectWithTag ("Player");
		Enemy = GameObject.FindGameObjectWithTag ("Enemy");

		//ゲームオブジェクトの座標コンポーネントの取得
		PlayerTrans = Player.GetComponent<Transform> ();
		EnemyTrans = Enemy.GetComponent<Transform> ();
	}

	void Update(){
		//距離を取得
		float range=Measure (PlayerTrans,EnemyTrans);

		//テキストに出力
		EMText.text = range.ToString("f1")+"m";

		//スクロールバーに表示
		EMScrollber.value = 1-range/MeasureLimit;
	}

	/// <summary>
	/// 2つのゲームオブジェクトの距離を測る関数
	/// </summary>
	float Measure(Transform obj1,Transform obj2){
		float px=obj1.position.x;
		float pz=obj1.position.z;

		float ex=obj2.position.x;
		float ez=obj2.position.z;

		return Mathf.Sqrt((px - ex) * (px - ex) + (pz - ez) * (pz - ez));
	}
}
