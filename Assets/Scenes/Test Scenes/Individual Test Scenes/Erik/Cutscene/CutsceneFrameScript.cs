using Assets.Scripts.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneFrameScript : MonoBehaviour {

	public GameObject NextFrame;
	public bool UseTimer;
	public float TimeUntilNextFrame;

	private Timer timer;
	public float TimeLeft = 0.0f;

	void Start() {
		if (UseTimer) {
			timer = new Timer(TimeUntilNextFrame);
		}
	}

	void Update() {
		if (UseTimer) {
			if (timer.Update()) {
				SwitchFrame();
			}
			TimeLeft = timer.TimeLeft();
		}
	}

	public void SwitchFrame() {
		if (NextFrame == null) {
			
			GetComponentInParent<CutsceneScript>().SwitchScene();
			return;
		}
		NextFrame.SetActive(true);
		gameObject.SetActive(false);
	}
}
