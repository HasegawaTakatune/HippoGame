using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class G1_GameManager : MonoBehaviour {

	public float slidespd = .1f;

	void Awake(){
		// シーンをまたいでもオブジェクトが削除されない処理
		DontDestroyOnLoad (gameObject);
		// シーンロード時のコールバックを登録
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnSceneLoaded(Scene scene,LoadSceneMode sceneMode){
		Button button;

		if (null != (button = GameObject.Find ("StartButton").GetComponent<Button> ())) {
			button.onClick.AddListener (() => GameStart ());
			button = null;
		}
		/*if (null != (button = GameObject.Find ("ExitButton").GetComponent<Button> ())) {
			button.onClick.AddListener (() => GameEnd ());
			button = null;
		}
		if (null != (button = GameObject.Find ("TitleButton").GetComponent<Button> ())) {
			button.onClick.AddListener (() => GameTitle ());
			button = null;
		}*/
	}

	public void GameStart(){
		SceneManager.LoadScene ("Main");
	}

	public void GameEnd(){
		Application.Quit ();
	}

	public void GameTitle(){
		SceneManager.LoadScene ("Title");
	}
}
