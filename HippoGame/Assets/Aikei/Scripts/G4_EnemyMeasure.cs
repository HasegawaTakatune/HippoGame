using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class G4_EnemyMeasure : MonoBehaviour {
	[SerializeField]
	Slider EMSlider;

	[SerializeField]
	Text EMText;

	GameObject Player;
	GameObject Enemy;

	void Start(){
		Player = GameObject.FindGameObjectWithTag ("Player");
		Enemy = GameObject.FindGameObjectWithTag ("Enemy");
	}

	void Update(){
		Measure ();
	}

	void Measure(){
		
	}
}
