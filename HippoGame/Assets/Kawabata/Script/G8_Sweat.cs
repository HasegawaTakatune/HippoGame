using UnityEngine;

public class G8_Sweat : MonoBehaviour {

	[SerializeField]
	GameObject SweatObject=null; //水たまりのオブジェクト

    void Start()
    {
        Destroy(gameObject, 15);
    }

	private void OnCollisionEnter(Collision col){
		if (col.gameObject.CompareTag ("Floor")) {   //"Floor"のタグにぶつかったら
			SweatSpread (col.gameObject);			 //SweatSpread()関数に飛ぶ
		}
	}

	private void SweatSpread(GameObject floor){
        Transform tt = transform;
		Instantiate (SweatObject, new Vector3(tt.position.x, tt.position.y - .1f, tt.position.z), Quaternion.identity);　//(水溜りのオブジェクト,体液の座標,回転無し)
		Destroy (gameObject);						//体液の削除
	}

}
