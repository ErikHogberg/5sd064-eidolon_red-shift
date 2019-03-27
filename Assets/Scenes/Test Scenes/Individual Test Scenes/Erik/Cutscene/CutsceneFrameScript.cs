using Assets.Scripts;
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

	private bool switchFrame = false;

	void Start() {
		if (UseTimer) {
			timer = new Timer(TimeUntilNextFrame);
		}
	}

	void Update() {
		if (switchFrame) {
			if (Globals.FadePanel.IsDone()) {
				NextFrame.SetActive(true);
				gameObject.SetActive(false);
			}
			return;
		}

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
		//Globals.FadePanel.StartLerpOut();
		//switchFrame = true;
		NextFrame.SetActive(true);
		gameObject.SetActive(false);
	}
}
