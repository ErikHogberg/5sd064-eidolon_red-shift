using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitScript : MonoBehaviour {

	public DialoguePanelScript DialogueWindow;
	public NotificationScript NotificationWindow;
	public FadeScript FadePanel;
	public Image GameOverPanel;

	//public Texture2D CursorTexture;
	//public Vector2 CursorOffset;

	void Start() {
		Globals.DialogueWindow = DialogueWindow;
		Globals.NotificationWindow = NotificationWindow;
		Globals.FadePanel = FadePanel;
		Globals.GameOverPanel = GameOverPanel;
	}

	void Update() {

	}

	private void OnMouseEnter() {
		//Cursor.visible = false;
		//Cursor.SetCursor(CursorTexture, CursorOffset, CursorMode.Auto);
	}

}
