using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Assets.Scripts;

public class TextScript : MonoBehaviour {

	private int tempScore = 0;
	private Text scoreText;
	private string text;

	// Start is called before the first frame update
	void Start() {
		scoreText = GetComponent<Text>();
		text = scoreText.text;
		scoreText.text = text + " " + tempScore;
	}

	protected void UpdateValue(int value) {
		if (tempScore != value) {
			tempScore = value;
			scoreText.text = text + " " + tempScore;
		}
	}
}
