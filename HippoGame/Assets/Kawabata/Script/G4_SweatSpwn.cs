using System.Collections;
using UnityEngine;

public class G4_SweatSpwn : MonoBehaviour
{

    [SerializeField]
    float interval = 0;   //生成速度
    [SerializeField]
    GameObject sweatobj = null; //体液のオブジェクト
    [SerializeField]
    Transform shootPoint = null; //発射地点(カバ)
    [SerializeField]
    Transform target = null;//狙う場所(プレイヤー)
    [SerializeField]
    float axis = 0;   //角度

    void Start()
    {
        StartCoroutine("Spawn");
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            Shoot(target.position);
            yield return new WaitForSeconds(interval);
        }
    }

    private void Shoot(Vector3 target)
    {
        // axisで指定した角度で飛ばす
        ShootFixedAngle(target, axis); //カバからプレイヤー向かって射出する角度
    }

    private void ShootFixedAngle(Vector3 target, float angle)
    {
        float speedVec = ComputeVectorFromAngle(target, angle);
        if (speedVec <= 0.0f)
        {
            //Debug.LogWarning( "!!" );
            return;
        }
        Vector3 vec = ConvertVectorToVector3(speedVec, angle, target);
        InstantiateShootObject(vec);
    }

    private float ComputeVectorFromAngle(Vector3 target, float angle)
    {
        // xz平面の距離を計算。
        float distance = Vector2.Distance(new Vector2(target.x, target.z), new Vector2(shootPoint.position.x, shootPoint.position.z));

        float x = distance;
        float g = Physics.gravity.y;
        float y0 = shootPoint.transform.position.y;
        float y = target.y;

        // Mathf.Cos() Mathf.Tan()に渡す値の単位はラジアン
        float rad = angle * Mathf.Deg2Rad;

        float cos = Mathf.Cos(rad);
        float tan = Mathf.Tan(rad);

        float v0Square = g * x * x / (2 * cos * cos * (y - y0 - x * tan));


        // -の値場合はこれ以上の計算は打ち切る
        if (v0Square <= 0.0f)
        {
            return 0.0f;
        }

        return (Mathf.Sqrt(v0Square));
    }

    private Vector3 ConvertVectorToVector3(float v0, float angle, Vector3 target)
    {
        Vector3 startPos = shootPoint.position;
        Vector3 targetPos = target;
        startPos.y = 0.0f;
        targetPos.y = 0.0f;

        Quaternion yawRot = Quaternion.FromToRotation(Vector3.right, ((targetPos - startPos).normalized));

        return yawRot * Quaternion.AngleAxis(angle, Vector3.forward) * (v0 * Vector3.right);//vec;
    }

    private void InstantiateShootObject(Vector3 shootVector)
    {
        if (sweatobj == null)
        {
            throw new System.NullReferenceException("sweatobj");
        }

        if (shootPoint == null)
        {
            throw new System.NullReferenceException("shootPoint");
        }

        var obj = Instantiate<GameObject>(sweatobj, shootPoint.position, Quaternion.identity);
        var rigidbody = obj.AddComponent<Rigidbody>();

        // 速さベクトルのままAddForce()を渡してはいけないぞ。力(速さ×重さ)に変換するんだ
        rigidbody.AddForce((shootVector * rigidbody.mass), ForceMode.Impulse);
    }
}

