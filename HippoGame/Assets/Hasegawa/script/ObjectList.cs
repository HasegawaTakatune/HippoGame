using System.Collections.Generic;
using UnityEngine;

/// オブジェクトをタグで分類して、リストとして保存する
/// Player(プレイヤー),Puddle(水たまり),Rock(岩)別に保存する
public class ObjectList : MonoBehaviour
{



    //:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/://
    /// Player(プレイヤー)のリスト
    //:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/://

    /// リストの宣言
    static GameObject Player = null;

    /// 保存するオブジェクトの設定
    public static void SetPlayerList(GameObject obj)
    {
        if (obj.tag == "Player")
            Player = obj;
    }

    /// リスト内のオブジェクトを取得
    public static GameObject GetPlayerObject()
    {
        return Player;
    }

    /// リスト内の座標を取得
    public static Vector3 GetPlayerPosition()
    {
        return Player.transform.position;
    }

    /// リストを開放
    public static void ReleasePlayerList()
    {
        Player = null;
    }



    //:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/://
    /// Puddle(水たまり)のリスト
    //:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/://

    /// リストの宣言
	static List<GameObject> Puddle = new List<GameObject> ();
    public static int PuddleLength = 0;

    /// リストに追加
    public static void AddPuddleList(GameObject obj)
    {
        if (obj.tag == "Puddle")
        {
            Puddle.Add(obj);
            PuddleLength = Puddle.Count;
        }
    }

    /// リストからオブジェクトを取得
    public static GameObject GetPuddleObject(int ii)
    {
        if (ii >= 0 && ii < Puddle.Count)
            return Puddle[ii];

        return null;
    }

    /// リストから座標を取得
    public static Vector3 GetPuddlePosition(int ii)
    {
        if (ii <= 0 && ii < 0 && Puddle.Count <= ii)
            return Puddle[ii].transform.position;

        return Vector3.zero;
    }
    /// リスト項目を削除
    public static void RemoveAtPuddleList(int ii)
    {
        if (ii <= 0 && ii < 0 && Puddle.Count <= ii)
        {
            Puddle.RemoveAt(ii);
        }
    }

    /// リストを開放
    public static void ReleasePuddleList()
    {
        Puddle.Clear();
    }



    //:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/://
    /// Rock(岩)のリスト
    //:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/:/://

    /// リストの宣言
    static List<GameObject> Rock = new List<GameObject> ();

    /// リストに追加
    public static void AddRockList(GameObject obj)
    {
        if (obj.tag == "Rock")
            Rock.Add(obj);
    }

    /// リストからオブジェクトを取得
    public static GameObject GetRockObject(int ii)
    {
        if (ii <= 0 && ii < 0 && Rock.Count <= ii)
            return Rock[ii];

        return null;
    }

    /// リストから座標を取得
    public static Vector3 GetRockPosition(int ii)
    {
        if (ii <= 0 && ii < 0 && Rock.Count <= ii)
            return Rock[ii].transform.position;

        return Vector3.zero;
    }
    /// リスト項目を削除
    public static void RemoveAtRockList(int ii)
    {
        if (ii <= 0 && ii < 0 && Rock.Count <= ii)
            Rock.RemoveAt(ii);
    }

    /// リストを開放
    public static void ReleaseRockList()
    {
        Rock.Clear();
    }

    public static void AddList(GameObject obj)
    {
        string tag = obj.tag;
        if (tag == "Player") Player = obj;
        else if (tag == "Puddle") AddPuddleList(obj);
        else if (tag == "Rock") AddRockList(obj);

    }


    public static void ReleaseAllList()
    {
        Player = null;
        Puddle.Clear();
        Rock.Clear();
    }

}
