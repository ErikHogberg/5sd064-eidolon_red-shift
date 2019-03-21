using Assets.Scripts.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour {

	public float Time;
	public bool FadeOut;
	public string NextLevel;


	private Image blackImage;
	private Timer timer;

	public float timerTime;
	public float alphaTemp;

	void Start() {
		blackImage = GetComponent<Image>();
		timer = new Timer(Time);

		Color color = blackImage.color;
		if (FadeOut) {
			color.a = 0.0f;
		} else {
			color.a = 1.0f;
		}
		blackImage.color = color;
	}

	void Update() {
		if (timer.Update()) {
			if (FadeOut) {
				SceneManager.LoadScene(NextLevel, LoadSceneMode.Single);
			} else {
				gameObject.SetActive(false);
			}
		}
		CalcAlpha();
	}

	public void StartLevelTransition(string Level) {
		FadeOut = true;
		NextLevel = Level;
		timer.Restart(Time);
		gameObject.SetActive(true);
	}

	public void StartLevelTransition() {
		StartLevelTransition(NextLevel);
	}

	private void CalcAlpha() {
		float alpha = timer.TimeLeft() / Time;

		timerTime = timer.TimeLeft();
		if (FadeOut) {
			alpha = 1.0f - alpha;
		}

		alphaTemp = alpha;

		Color color = blackImage.color;
		color.a = alpha;
		blackImage.color = color;

	}

}
