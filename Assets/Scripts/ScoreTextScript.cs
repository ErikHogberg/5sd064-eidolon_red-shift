using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;

public class ScoreTextScript : MonoBehaviour {

	private int tempScore;
	private Text scoreText;

	// Start is called before the first frame update
	void Start() {
		tempScore = Globals.Score;
		scoreText = GetComponent<Text>();
	}

	// Update is called once per frame
	void Update() {
		if (tempScore != Globals.Score) {
			tempScore = Globals.Score;
			scoreText.text = "Score: " + tempScore;
		}
	}
}
