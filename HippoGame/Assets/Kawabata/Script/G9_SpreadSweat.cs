using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G9_SpreadSweat : MonoBehaviour {

	[SerializeField]
	float SweatRange = 0;   //体液の横幅
	[SerializeField]
	float SweatSpreadTime = 0;  //体液が広がる速さ(大きいほど遅い)

	// Use this for initialization
	void Start () {
		StartCoroutine ("Spread", SweatSpreadTime);	
	}
	
	private  IEnumerator Spread(float Time){
		while (this.transform.localScale.x < SweatRange) { //Scale.xの数値がSweatRangeより小さいなら
			yield return new WaitForSeconds (Time);        
			this.transform.localScale += new Vector3 (0.1f, 0, 0);   //0.1ずつ横に伸ばす
		}

	}
}
