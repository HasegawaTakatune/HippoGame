using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class G1_GameManager : MonoBehaviour
{

    public const byte Title = 0, Play = 1, GameClear = 2, GameOver = 3;
    public static byte GameStatus = Title;
    public static bool isPlay() { return GameStatus == Play; }

    /// <summary>
    /// 初期化
    /// </summary>
    void Awake()
    {
        // シーンをまたいでもオブジェクトが削除されない処理
        DontDestroyOnLoad(gameObject);
        // シーンロード時のコールバックを登録
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    /// <summary>
    /// シーンがロードされた際のロールバック
    /// </summary>
    void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
    {
        // シーンに設置されているボタンに制御を加えていく
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Button"))
        {
            if (obj.name == "StartButton")
                obj.GetComponent<Button>().onClick.AddListener(() => GameStart());
            else if (obj.name == "ExitButton")
                obj.GetComponent<Button>().onClick.AddListener(() => GameEnd());
            else if (obj.name == "TitleButton")
                obj.GetComponent<Button>().onClick.AddListener(() => GameTitle());
        }
    }

    /// <summary>
    /// メインゲームのシーンに移動
    /// </summary>
    public void GameStart()
    {
        GameStatus = Play;
        SceneManager.LoadScene("Main");
    }

    /// <summary>
    /// ゲームを終了して、ウィンドウを閉じる
    /// </summary>
    public void GameEnd()
    {
        Application.Quit();
    }

    /// <summary>
    /// ゲームタイトルのシーンに移動
    /// </summary>
    public void GameTitle()
    {
        GameStatus = Title;
        SceneManager.LoadScene("Title");
    }
}
