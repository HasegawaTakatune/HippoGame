using UnityEngine;

public class G7_Slide : MonoBehaviour
{
    const float slidespd = 0.1f;    //このオブジェクトのスライド量を保存する
    Transform trans;	        //使うTransformを保存する変数宣言

    Vector3 movement;           // 移動量の格納

    [SerializeField]
    float zpos = -6;      // 削除するｚ座標

    [SerializeField]
    bool isDestroy = false;

    void Start()
    {
        //このオブジェクトのTransformを格納する
        trans = gameObject.transform;

        movement = new Vector3(0, 0, slidespd);
    }

    void Update()
    {
        trans.position -= movement;
        if (isDestroy && trans.position.z < zpos) Destroy(gameObject);
    }
}
