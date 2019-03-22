using Assets.Scripts.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteColorEaseScript : MonoBehaviour
{
	public Color TargetColor;
	private Color startColor;

	public float Time;
	public bool FadeOut;
	public AnimationCurve Easing;

	private SpriteRenderer sprite;
	private Timer timer;

	void Start() {
		sprite = GetComponent<SpriteRenderer>();
		startColor = sprite.color;
		timer = new Timer(Time);

		if (FadeOut) {
			sprite.color = startColor;
		} else {
			sprite.color = TargetColor;
		}

		//easing = AnimationCurve.EaseInOut(0.85f, 0.15f, 0.15f, 0.85f);
	}

	void Update() {
		timer.Update();
		CalcColor();
		if (Input.GetKeyDown(KeyCode.L)) {
			StartLerpIn();
		}
		if (Input.GetKeyDown(KeyCode.K)) {
			StartLerpOut();
		}

	}

	public void StartLerpOut() {
		FadeOut = true;
		timer.Restart(Time);
	}

	public void StartLerpIn() {
		FadeOut = false;
		timer.Restart(Time);
	}

	private void CalcColor() {

		float timerTime = timer.TimeLeft();
		if (!timer.IsRunning()) {
			timerTime = 0.0f;
		}

		float t = Easing.Evaluate(timerTime / Time);
		if (FadeOut) {
			t = 1.0f - t;
		}

		sprite.color = Color.Lerp(startColor, TargetColor, t);

	}
}
