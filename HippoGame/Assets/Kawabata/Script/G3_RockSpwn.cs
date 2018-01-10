﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G3_RockSpwn : MonoBehaviour {


	[SerializeField]
	float spwnspd;   //生成速度
	[SerializeField]
	byte spwnnum;    //生成個数
	[SerializeField]
	GameObject rockobj; //岩のオブジェクト
	[SerializeField]
	float random_x1,random_x2; //ランダムの範囲 x1:最低値 x2:最大値
	private int createcnt; //for文に使う生成カウント

	// Use this for initialization
	private void Start () {
		StartCoroutine ("Spwn");
	}
	private  IEnumerator Spwn(){
		while (true) {
			for (createcnt = 0; createcnt < spwnnum; createcnt++) {
				Vector3 position = new Vector3 (Random.Range (random_x1, random_x2), 1, 3.5f);
				Instantiate (rockobj, position, Quaternion.identity);
			}
			yield return new WaitForSeconds (spwnspd);
		}
	}
}