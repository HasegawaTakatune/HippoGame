using UnityEngine;

public class P3_Puddle : MonoBehaviour
{

    // スリップ速度
    [SerializeField]
    float slidespd = .1f;
    // Transform格納
    Transform trans;
    AudioSource audioSource;
    /// 入水音の登録
    public AudioClip[] LandingSound;
    int clipLength;


    /// <summary>
    /// 初期化
    /// </summary>
    void Start()
    {
        trans = transform;
        audioSource = GetComponent<AudioSource>();
        clipLength = LandingSound.Length;
    }

    /// <summary>
    /// スリップ処理
    /// </summary>
    void Puddle()
    {
        trans.position -= trans.forward * slidespd;
    }

    /// <summary>
    /// 当たり判定（触れ続けている有効）
    /// </summary>
    void OnTriggerStay(Collider collider)
    {
        string tag = collider.gameObject.tag;
        if (tag == "Puddle" || tag == "Sweat")
        {
            Puddle();
            if (!audioSource.isPlaying)
                audioSource.PlayOneShot(LandingSound[Random.Range(0, clipLength)]);
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        string tag = collider.gameObject.tag;
        if (tag == "Puddle" || tag == "Sweat")
        {
            // 着水音を再生
            if (LandingSound != null)
                audioSource.PlayOneShot(LandingSound[Random.Range(0, clipLength)]);
        }
    }

}
