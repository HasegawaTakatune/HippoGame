using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E4_Puddle : MonoBehaviour {

	/// オーディオの再生先を格納
	AudioSource audioSource;
	/// 入水音の登録
	public AudioClip LandingSound;
	/// 離水音
	public AudioClip DrainSound;

	/// E1_Moveを格納
	E1_Move move;

	/// 水中にいる際の加速度
	[SerializeField] float puddlespd = .2f;

	/// 初期化
	void Start () {
		move = GetComponent<E1_Move> ();
		audioSource = GetComponent<AudioSource> ();
	}

	/// 水たまりに入ったかの判定をする
	void OnTriggerEnter(Collider collider){
		if (collider.tag == "Puddle") {

			// 着水音を再生
			if (LandingSound != null) 
				audioSource.PlayOneShot (LandingSound);

			// 着水時の速度に変更
			Puddle (true);
		}
	}

	/// 水たまりから離れたかの判定をする
	void OnTriggerExit(Collider collider){
		if (collider.tag == "Puddle") {

			// 離水音を再生
			if (DrainSound != null)
				audioSource.PlayOneShot (DrainSound);

			// 離水時の速度に変更
			Puddle (false);
		}
	}

	/// 加速・減速をする
	void Puddle(bool flg){
		move.Speed += (flg) ? puddlespd : -puddlespd;
	}
}
