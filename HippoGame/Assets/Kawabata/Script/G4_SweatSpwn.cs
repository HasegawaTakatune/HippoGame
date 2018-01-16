using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G4_SweatSpwn : MonoBehaviour {

	[SerializeField]
	float spwnspd =0;   //生成速度
	[SerializeField]
	byte spwnnum =0;    //生成個数
	[SerializeField]
	GameObject sweatobj = null; //体液のオブジェクト
	[SerializeField]
	Transform shootPoint    = null; //発射地点(カバ)
	[SerializeField]
	Transform target        = null;//狙う場所(プレイヤー)
	private int createcnt; //for文に使う生成カウント

	// Use this for initialization
	void Start () {
		StartCoroutine ("Spwn");
	}

	private  IEnumerator Spwn(){
		while (true) {
			for (createcnt = 0; createcnt < spwnnum; createcnt++) {
				Shoot( target.position );				
			}
			yield return new WaitForSeconds (spwnspd);
		}
	}
	private void Shoot( Vector3 i_targetPosition )
	{
		// とりあえず適当に60度でかっ飛ばすとするよ！
		ShootFixedAngle( i_targetPosition, 60.0f );　//カバからプレイヤー向かって射出する角度
	}

	private void ShootFixedAngle( Vector3 i_targetPosition, float i_angle )
	{
		float speedVec  = ComputeVectorFromAngle( i_targetPosition, i_angle );
		if( speedVec <= 0.0f )
		{
			// その位置に着地させることは不可能のようだ！
			Debug.LogWarning( "!!" );
			return;
		}

		Vector3     vec = ConvertVectorToVector3( speedVec, i_angle, i_targetPosition );
		InstantiateShootObject( vec );
	}

	private float ComputeVectorFromAngle( Vector3 i_targetPosition, float i_angle )
	{
		// xz平面の距離を計算。
		Vector2 startPos    = new Vector2( shootPoint.transform.position.x, shootPoint.transform.position.z );
		Vector2 targetPos   = new Vector2( i_targetPosition.x, i_targetPosition.z );
		float distance      = Vector2.Distance( targetPos, startPos );

		float x     = distance;
		float g     = Physics.gravity.y;
		float y0    = shootPoint.transform.position.y;
		float y     = i_targetPosition.y;

		// Mathf.Cos()、Mathf.Tan()に渡す値の単位はラジアンだ。角度のまま渡してはいけないぞ！
		float rad   = i_angle * Mathf.Deg2Rad;

		float cos   = Mathf.Cos( rad );
		float tan   = Mathf.Tan( rad );

		float v0Square  = g * x * x / ( 2 * cos * cos * ( y - y0 - x * tan ) );

		// 負数を平方根計算すると虚数になってしまう。
		// 虚数はfloatでは表現できない。
		// こういう場合はこれ以上の計算は打ち切ろう。
		if( v0Square <= 0.0f )
		{
			return 0.0f;
		}

		float v0    = Mathf.Sqrt( v0Square );
		return v0;
	}

	private Vector3 ConvertVectorToVector3( float i_v0, float i_angle, Vector3 i_targetPosition )
	{
		Vector3     startPos    = shootPoint.transform.position;
		Vector3     targetPos   = i_targetPosition;
		startPos.y  = 0.0f;
		targetPos.y = 0.0f;

		Vector3     dir     = ( targetPos - startPos ).normalized;
		Quaternion yawRot   = Quaternion.FromToRotation( Vector3.right, dir );
		Vector3     vec     = i_v0 * Vector3.right;

		vec     = yawRot * Quaternion.AngleAxis( i_angle, Vector3.forward ) * vec;

		return vec;
	}

	private void InstantiateShootObject( Vector3 i_shootVector )
	{
		if( sweatobj == null )
		{
			throw new System.NullReferenceException( "sweatobj" );
		}

		if( shootPoint == null )
		{
			throw new System.NullReferenceException( "shootPoint" );
		}

		var obj         = Instantiate<GameObject>( sweatobj, shootPoint.position, Quaternion.identity );
		var rigidbody   = obj.AddComponent<Rigidbody>();

		// 速さベクトルのままAddForce()を渡してはいけないぞ。力(速さ×重さ)に変換するんだ
		Vector3 force   = i_shootVector * rigidbody.mass;

		rigidbody.AddForce( force, ForceMode.Impulse );
	}
}

