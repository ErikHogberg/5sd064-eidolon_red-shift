using Assets.Scripts.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationScript : MonoBehaviour {

	public float VisibleTime;
	public float BlinkTime;
	private Timer timer;
	private Timer blinkTimer1;
	private Timer blinkTimer2;

	private Color color;
	public Color BlinkColor;

	bool Init = false;

	void Start() {
		if (!Init) {
			color = GetComponent<Image>().color;
			Init = true;
		}

		GetComponent<Image>().color = BlinkColor;

		timer = new Timer(VisibleTime);
		blinkTimer1 = new Timer(BlinkTime);
		blinkTimer2 = new Timer(VisibleTime - BlinkTime * 2.0f);
	}

	void Update() {
		if (timer.Update()) {
			gameObject.SetActive(false);
		}
		if (blinkTimer1.Update()) {
			GetComponent<Image>().color = color;
		}
		if (blinkTimer2.Update()) {
			GetComponent<Image>().color = BlinkColor;
		}
	}

	public void Show(string text) {
		Start();
		GetComponentInChildren<Text>().text = text;
		timer.Restart();
		gameObject.SetActive(true);
	}
}
