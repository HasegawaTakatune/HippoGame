using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_Move : MonoBehaviour {

	/// 移動速度
	[SerializeField]float movespd = .2f;
	public float Speed{get{ return movespd;}set{ movespd = value;}}
	/// 初期Z座標
	float initZ = 0;

	/// 敵の強さ
	[SerializeField]byte nowlevel = 1;
	/// ステータス
	[SerializeField]byte nowState = STATUS.STR;
	public byte Status{get{ return nowState;}set{ nowState = value;}}
	/// 回避フラグ
	bool avoidance = false;
	/// 回避方向
	float direc;

	/// ターゲット・ターゲットタグ
	[SerializeField]GameObject nowTarget;
	string targetTag = "Player";

	/// 岩を避けるフラグ
	[SerializeField]bool rockFlg;

	/// Transformのキャスト
	Transform myTransform;

	/// 初期化
	void Start () {
		myTransform = transform;

		initZ = myTransform.position.z;
	}

	/// メインループ
	void Update () {
		State ();	
	}

	/// ステータスごとの関数呼び出し
	void State(){
		// ステータス遷移
		switch (nowState) {

		case STATUS.IDLE:	// 待機状態
			Idle ();
			break;

		case STATUS.STR:	// 突進（攻撃）
			Strike ();
			break;
		}
	}

	/// 待機時の処理
	/// 初期位置まで戻り、次にとる行動の選択をする
	void Idle(){
		if (transform.position.z <= initZ)
			InitStrike ();
	}

	/// 突進（攻撃）をするための初期設定
	void InitStrike(){
		// ターゲット設定
		MasterTarget ();
		// ターゲットに向く
		RotCalcu ();
		// ステータスを突進（攻撃）にする
		nowState = STATUS.STR;
	}

	/// 突進（攻撃）をする
	void Strike(){
		/// ターゲット方向を求める
		float angle = GetDegree (transform.position, nowTarget.transform.position);
		/// 移動ベクトル
		Vector3 movement = new Vector3 (
			Mathf.Cos (angle * 3.14f / 180),
			0,
			1) * movespd;

		// 岩を避けるか突っ切るかを判定
		if (rockFlg) {
			// 回避行動をとるかを判定
			if (avoidance) {
				// 回避する
				myTransform.position += new Vector3 (direc, 0, 0) * movespd;
			} else {
				// 進行方向に岩があるかを調べて、ある場合には回避行動に入る
				// そうでなければそのまま進む
				if (Physics.Raycast (myTransform.position, movement, 5, 1 << LayerMask.NameToLayer ("Rock"))) {
					direc = Mathf.Sign(movement.x);
					StartCoroutine(ToAvoid());
				} else
					myTransform.position += movement;
			}
		} else
			myTransform.position += movement;

		// ターゲットを通り過た際の処理
		if (nowTarget.transform.position.z < myTransform.position.z - 5) {
			if (targetTag == "Player")	// ターゲットがプレイヤの場合、待機状態にする
				nowState = STATUS.IDLE;
			else
				InitStrike ();			// それ以外の場合、次のターゲットを探す
		}
	}

	/// 一定時間、回避行動をとる
	IEnumerator ToAvoid(){
		avoidance = true;
		yield return new WaitForSeconds (.2f);
		avoidance = false;
	}

	/// ターゲット設定をする
	void MasterTarget(){
		switch (nowlevel) {
		case Game.LEVEL1:
			break;

		case Game.LEVEL2:
			break;

		case Game.LEVEL3:
			break;
		}
	}

	void SetPlayerTag(){
	}

	void SetPuddleTag(){
	}

	void SetRockFlg(){
	}

	float Range(){
		return 0;
	}

	// ターゲット方向に向く
	void RotCalcu(){
	}


	/// 座標XとZの値から、2点間の角度を求める
	float GetDegree(Vector3 pp1,Vector3 pp2){
		float xx = pp2.x - pp1.x;
		float zz = pp2.z - pp1.z;
		float rad = Mathf.Atan2 (zz, xx);
		return rad * Mathf.Rad2Deg;
	}

}
