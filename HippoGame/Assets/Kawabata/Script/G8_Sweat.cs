using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G8_Sweat : MonoBehaviour {

	[SerializeField]
	GameObject SweatObject=null; //水たまりのオブジェクト

	[SerializeField]
	Transform sweat_pos_y;		//生成されるY座標は固定する
	private void OnCollisionEnter(Collision col){
		if (col.gameObject.CompareTag ("Floor")) {   //"Floor"のタグにぶつかったら
			SweatSpread (col.gameObject);			 //SweatSpread()関数に飛ぶ


		}
	}

	private void SweatSpread(GameObject floor){
		Vector3 sweat_pos = this.transform.position;  //Floorに触れた時の体液の座標取得
		sweat_pos = new Vector3(this.transform.position.x,sweat_pos_y.position.y,this.transform.position.z);
		Instantiate (SweatObject, sweat_pos, Quaternion.identity);　//(水溜りのオブジェクト,体液の座標,回転無し)
		Destroy (this.gameObject);						//体液の削除
	}

}
