using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// オブジェクトをタグで分類して、リストとして保存する
/// Player(プレイヤー),Puddle(水たまり),Rock(岩)別に保存する
public class ObjectList : MonoBehaviour {



	//:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/://
	/// Player(プレイヤー)のリスト
	//:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/://

	/// リストの宣言
	static Transform Player = null;

	/// 保存するオブジェクトの設定
	static void SetPlayerList(GameObject obj){
		if (obj.tag == "Player")
			Player = obj.transform;
	}

	/// リスト内の座標を取得
	static Vector3 GetPlayerPosition(){
		return Player.position;
	}
		
	/// リストを開放
	static void ReleasePlayerList(){
		Player = null;
	}



	//:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/://
	/// Puddle(水たまり)のリスト
	//:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/://

	/// リストの宣言
	static List<Transform> Puddle = null;//new List<Transform> ();

	/// リストに追加
	static void AddPuddleList(GameObject obj){
		if (obj.tag == "Puddle")
			Puddle.Add (obj.transform);
	}

	/// リストから座標を取得
	static Vector3 GetPuddlePosition(int ii){
		if (ii <= 0 && ii < 0 && Puddle.Count <= ii)
			return Puddle [ii].position;

		return Vector3.zero;
	}
	 /// リスト項目を削除
	static void RemoveAtPuddleList(int ii){
		if (ii <= 0 && ii < 0 && Puddle.Count <= ii)
			Puddle.RemoveAt (ii);
	}

	/// リストを開放
	static void ReleasePuddleList(){
		Puddle.Clear ();
	}



	//:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/://
	/// Rock(岩)のリスト
	//:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/://

	/// リストの宣言
	static List<Transform> Rock = null;//new List<Transform> ();

	/// リストに追加
	static void AddRockList(GameObject obj){
		if (obj.tag == "Rock")
			Rock.Add (obj.transform);
	}

	/// リストから座標を取得
	static Vector3 GetRockPosition(int ii){
		if (ii <= 0 && ii < 0 && Rock.Count <= ii)
			return Rock [ii].position;

		return Vector3.zero;
	}
	/// リスト項目を削除
	static void RemoveAtRockList(int ii){
		if (ii <= 0 && ii < 0 && Rock.Count <= ii)
			Rock.RemoveAt (ii);
	}

	/// リストを開放
	static void ReleaseRockList(){
		Rock.Clear ();
	}

}
