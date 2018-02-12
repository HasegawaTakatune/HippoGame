using System.Collections;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    [SerializeField]
    float interval = 0;   //生成速度
    [SerializeField]
    GameObject SpawnObj = null; //オブジェクト
    [SerializeField]
    float rand_min = 0, rand_max = 0; //ランダムの範囲 x1:最低値 x2:最大値
    float zz;

    private void Start()
    {
        zz = transform.position.z;
        StartCoroutine("Spawn");
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            Instantiate(SpawnObj, new Vector3(Random.Range(rand_min, rand_max), -0.8876438f, zz), Quaternion.identity);
            yield return new WaitForSeconds(interval);
        }
    }
}
