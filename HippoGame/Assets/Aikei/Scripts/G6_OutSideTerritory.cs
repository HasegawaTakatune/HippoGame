using UnityEngine;
using UnityEngine.UI;

public class G6_OutSideTerritory : MonoBehaviour
{
    [SerializeField]
    Text OSText;

    [SerializeField]
    Transform goal;//スタートからゴールまでの距離

    [SerializeField]
    Transform PlayerTrans;

    [SerializeField]
    GameObject GoalUI;

    void Update()
    {
        float range = Measure(PlayerTrans.position.z, goal.position.z);
        OSText.text = "GOAL:" + range.ToString("f1") + "m";
        if (range <= 1 && G1_GameManager.isPlay())
        {
            G1_GameManager.GameStatus = G1_GameManager.GameClear;
            GoalUI.SetActive(true);
        }
    }
    /// <summary>
    /// 2つのゲームオブジェクトの距離を測る関数
    /// </summary>
    float Measure(float obj1, float obj2)
    {
        return obj2 - obj1;
    }
}
