using UnityEngine;

public class G8_GameOver : MonoBehaviour
{
    [SerializeField]
    GameObject GameOverUI;

    void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag == "Enemy") GameOverUI.SetActive(true);
    }
}
