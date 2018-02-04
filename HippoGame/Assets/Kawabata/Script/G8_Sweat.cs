using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G8_Sweat : MonoBehaviour {

	[SerializeField]
	GameObject SweatObject=null; //水たまりのオブジェクト

	private void OnCollisionEnter(Collision col){
		if (col.gameObject.CompareTag ("Floor")) {   //"Floor"のタグにぶつかったら
			SweatSpread (col.gameObject);			 //SweatSpread()関数に飛ぶ


		}
	}

	private void SweatSpread(GameObject floor){
		Vector3 sweat_pos = this.transform.position;  //Floorに触れた時の体液の座標取得
		Instantiate (SweatObject, sweat_pos, Quaternion.identity);　//(水溜りのオブジェクト,体液の座標,回転無し)
		Destroy (this.gameObject);						//体液の削除
	}

}
