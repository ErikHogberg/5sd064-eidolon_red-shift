using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitScript : MonoBehaviour {

	public DialoguePanelScript DialogueWindow;

	void Start() {
		Globals.DialogueWindow = DialogueWindow;
	}

	void Update() {

	}

}
