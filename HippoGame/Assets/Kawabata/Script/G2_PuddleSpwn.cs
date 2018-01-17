using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G2_PuddleSpwn : MonoBehaviour {


	[SerializeField]
	float spwnspd;   //生成速度
	[SerializeField]
	byte spwnnum;    //生成個数
	[SerializeField]
	GameObject puddleobj; //水たまりのオブジェクト
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
				Vector3 position = new Vector3 (Random.Range (random_x1, random_x2), -0.8876438f, 3.5f);
				Instantiate (puddleobj, position, Quaternion.identity);
			}
			yield return new WaitForSeconds (spwnspd);
		}
	}
}
