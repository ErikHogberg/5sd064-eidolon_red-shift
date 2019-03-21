using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitScript : MonoBehaviour {

	public DialoguePanelScript DialogueWindow;
	public NotificationScript NotificationWindow;
	public FadeScript FadePanel;
	//public Texture2D CursorTexture;
	//public Vector2 CursorOffset;

	void Start() {
		Globals.DialogueWindow = DialogueWindow;
		Globals.NotificationWindow = NotificationWindow;
		Globals.FadePanel = FadePanel;
	}

	void Update() {

	}

	private void OnMouseEnter() {
		//Cursor.visible = false;
		//Cursor.SetCursor(CursorTexture, CursorOffset, CursorMode.Auto);
	}

}
