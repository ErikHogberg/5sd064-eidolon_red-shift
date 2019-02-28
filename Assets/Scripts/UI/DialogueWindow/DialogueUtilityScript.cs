using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUtilityScript : MonoBehaviour {
	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {

	}

	public void ClickClose() {
		Globals.DialogueWindow.gameObject.SetActive(false);
	}

	public void ClickNext() {
		if (Globals.DialogueWindow.IsOnLastPage()) {
			Globals.DialogueWindow.gameObject.SetActive(false);
			return;
		}

		Text buttonText = GetComponentInChildren<Text>();
		if (Globals.DialogueWindow.NextPage()) {
			buttonText.text = "Close";
		} else {
			buttonText.text = "Next";
			// TODO: change next text back on prev button click
		}
	}

	public void ClickPrev() {


		Globals.DialogueWindow.PrevPage();
	}

}
