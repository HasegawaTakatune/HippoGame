using UnityEngine;

public class G8_GameOver : MonoBehaviour
{
    [SerializeField]
    GameObject GameOverUI;

    void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag == "Enemy" && G1_GameManager.isPlay())
        {
            G1_GameManager.GameStatus = G1_GameManager.GameOver;
            GameOverUI.SetActive(true);
        }
    }
}
