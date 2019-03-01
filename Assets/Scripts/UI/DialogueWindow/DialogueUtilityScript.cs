using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUtilityScript : MonoBehaviour {

	private string initText;

	private void Awake() {
		initText = GetComponentInChildren<Text>().text;
	}

	private void OnEnable() {
		//if (Globals.DialogueWindow.IsOnLastPage()) {
		//	GetComponentInChildren<Text>().text = "Close";
		//} else {
		GetComponentInChildren<Text>().text = initText;
		//}
	}

	void Start() {

	}

	void Update() {

	}

	public void ClickClose() {
		Globals.DialogueWindow.gameObject.SetActive(false);
	}

	public void ClickNext() {
		Text buttonText = GetComponentInChildren<Text>();

		if (Globals.DialogueWindow.IsOnLastPage()) {
			Globals.DialogueWindow.gameObject.SetActive(false);
			//buttonText.text = "Next";
			return;
		}

		if (Globals.DialogueWindow.NextPage()) {
			buttonText.text = "Close";
		} else {
			buttonText.text = initText;
			// TODO: change next text back on prev button click
		}
	}

	public void ClickPrev() {


		Globals.DialogueWindow.PrevPage();
	}

}
