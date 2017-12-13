using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class P1_Move : MonoBehaviour {

	// 速度
	//[SerializeField]float movespd = .2f;
	// Transform格納
	//Transform trans;

	/// <summary>
	/// 初期化
	/// </summary>
	void Start () {
	//	trans = transform;
	}

    /// <summary>
    /// メインループ
    /// </summary>
    void Update()
    {
        //Move ();
        if (transform.position.x < -3.5 )
        {
            transform.position = new Vector3(-3.5f,this.transform.position.y,this.transform.position.z);
        }
        if (transform.position.x > 3.5)
        {
            transform.position = new Vector3(3.5f, this.transform.position.y, this.transform.position.z);
        }
        float dx = Input.GetAxis("Horizontal");
            transform.Translate(dx / 2, 0, 0);
        
    }
        void OnCollisionStay(Collision other)
    {
            if (other.gameObject.tag == "enemy")
            {
            SceneManager.LoadScene("Title");
                Debug.Log("Hit");
            }
        }

        /// <summary>
        /// 左右移動
        /// </summary>
        /*void Move(){
		if (Input.GetKey (KeyCode.LeftArrow))
			trans.position -= trans.right * movespd;
		if (Input.GetKey (KeyCode.RightArrow))
			trans.position += trans.right * movespd;
	}*/
}
