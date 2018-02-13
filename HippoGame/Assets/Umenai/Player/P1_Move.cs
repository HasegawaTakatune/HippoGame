using UnityEngine;

public class P1_Move : MonoBehaviour
{
    private Animator animator;
    // ジャンプ速度
    [SerializeField]
    float jumpSpd = 1;
    // ジャンプ高さ
    [SerializeField]
    float jumpHeight = 1;
    // 天井
    float ceiling;
    // 床
    [SerializeField]float floor;
    // ジャンプ中判定
    bool isJump = false;
    // Transform格納
    Transform trans;
    // 上昇・下降の関数を格納
    System.Action action;
    // すみっこ
    [SerializeField]
    float corner = 5;

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
        action = () => Up();
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// メインループ
    /// </summary>
    void Update()
    {
        if (trans.position.x < -corner)
            trans.position = new Vector3(-corner, trans.position.y, trans.position.z);

        if (trans.position.x > corner)
            trans.position = new Vector3(corner, trans.position.y, trans.position.z);

        float dx = Input.GetAxis("Horizontal");
        trans.Translate(dx / 2, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space) && !isJump)
        {
            animator.SetTrigger("PlayerMove");
            isJump = true;
            ceiling = trans.position.y + jumpHeight;
        }

        // 上昇・下降の処理をする
        if (isJump)
            action();
    }

    void Up()
    {
        // 上昇
        trans.position += trans.up * jumpSpd;
        // 上昇限界処理
        if (trans.position.y >= ceiling)
            action = () => Down();
    }

    void Down()
    {
        // 下降
        trans.position -= trans.up * jumpSpd;
        // 着地処理
        if (trans.position.y <= floor)
        {
            isJump = false;
            action = () => Up();
        }
    }
}
