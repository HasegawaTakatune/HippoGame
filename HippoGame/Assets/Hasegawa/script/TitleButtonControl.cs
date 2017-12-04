using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleButtonControl : MonoBehaviour {

	void Awake() {
		GameObject.Find ("StartButton").GetComponent<Button> ().onClick.AddListener (() => OnClickStartButton ());
		GameObject.Find ("ExitButton").GetComponent<Button> ().onClick.AddListener (() => OnClickExitButton ());
	}

	public void OnClickStartButton(){
		SceneManager.LoadScene ("Main");
	}

	public void OnClickExitButton(){
		Application.Quit ();
	}

}
