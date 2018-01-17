using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G2_PuddleSpwn : MonoBehaviour {


	[SerializeField]
	float spwnspd =0;   //生成速度
	[SerializeField]
	byte spwnnum =0;    //生成個数
	[SerializeField]
	GameObject puddleobj = null; //水たまりのオブジェクト
	[SerializeField]
	float random_min,random_max =0; //ランダムの範囲 x1:最低値 x2:最大値
	private int createcnt=0; //for文に使う生成カウント

	// Use this for initialization
	private void Start () {
		StartCoroutine ("Spwn");
	}
	private  IEnumerator Spwn(){
		while (true) {
			for (createcnt = 0; createcnt < spwnnum; createcnt++) {
				                 //new Vector3(x(ランダム),y(固定値),z(固定値))　ランダムの範囲はInspectorで変更可
				Vector3 position = new Vector3 (Random.Range (random_min,random_max), 1, 3.5f);
				Instantiate (puddleobj, position, Quaternion.identity);
			}
			yield return new WaitForSeconds (spwnspd);
		}
	}
}
