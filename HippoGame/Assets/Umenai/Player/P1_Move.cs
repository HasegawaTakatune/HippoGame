using UnityEngine;

public class P1_Move : MonoBehaviour
{
    private Animator animator;
    // ジャンプ速度
    [SerializeField]
    float jumpspd = 1;
    // ジャンプ高さ
    [SerializeField]
    float jumpheight = 1;
    // 天井
    float ceiling;
    // ジャンプ中判定
    bool isjump = false;
    // Transform格納
    Transform trans;
    // 上昇・下降の関数を格納
    System.Action action;

    /// <summary>
    /// 初期化
    /// </summary>
    void Awake()
    {
        ObjectList.SetPlayerList(gameObject);
    }
    void Start()
    {
        trans = transform;
        ceiling = trans.position.y + jumpheight;
        action = () => Up();
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// メインループ
    /// </summary>
    void Update()
    {
        if (trans.position.x < -3.5)
            trans.position = new Vector3(-3.5f, trans.position.y, trans.position.z);

        if (trans.position.x > 3.5)
            trans.position = new Vector3(3.5f, trans.position.y, trans.position.z);

        float dx = Input.GetAxis("Horizontal");
        trans.Translate(dx / 2, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isjump = true;
            // 上昇・下降の処理をする
            if (isjump)
                action();
            animator.SetTrigger("PlayerMove");
        }
    }

    void Up()
    {
        // 上昇
        trans.position += trans.up * jumpspd;
        // 上昇限界処理
        if (trans.position.y >= ceiling)
            action = () => Down();
    }

    void Down()
    {
        // 下降
        trans.position -= trans.up * jumpspd;
        // 着地処理
        if (trans.position.y <= ceiling - jumpheight)
        {
            isjump = false;
            action = () => Up();
        }
    }
}
