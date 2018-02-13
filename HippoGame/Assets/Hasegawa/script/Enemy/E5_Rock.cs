using UnityEngine;

public class E5_Rock : MonoBehaviour
{

    /// オーディオの再生先を格納
    AudioSource audioSource;
    /// 岩の破壊音の登録
    [SerializeField]
    AudioClip[] BreakSound;
    int clipLength;

    /// E1_Moveを格納
    E1_Move move;
    /// カメラを格納
    GameObject _camera;
    /// 画面を揺らすためのx,y座標(Shake_x,Shake_y)と揺らす時間(Shake_Time)
    [SerializeField]
    float Shake_x = .3f, Shake_y = .3f, Shake_Time = .5f;

    /// 初期化
    void Start()
    {
        // E1_Moveを取得
        move = GetComponent<E1_Move>();
        // カメラを取得
        _camera = GameObject.FindGameObjectWithTag("MainCamera");

        audioSource = GetComponent<AudioSource>();

        clipLength = BreakSound.Length;
    }

    /// アイドル状態にする
    void Rock()
    {
        move.Status = STATUS.IDLE;
    }

    /// 画面を揺らす
    void Shake()
    {
        iTween.ShakePosition(_camera, iTween.Hash("x", Shake_x, "y", Shake_y, "time", Shake_Time));
    }

    /// 岩に衝突したかを判定する
    void OnCollisionEnter(Collision collision)
    {
        // 岩に衝突した場合、アイドル状態にして画面を揺らす
        // 岩は破壊される
        if (collision.transform.tag == "Rock")
        {

            // 岩の破壊音を再生
            if (clipLength > 0)
                audioSource.PlayOneShot(BreakSound[Random.Range(0, clipLength)]);

            Rock();
            Shake ();
            Destroy(collision.gameObject);
        }
    }
}
