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

	public BoxCollider2D UpperBoundary;
	public BoxCollider2D LowerBoundary;

	//public Texture2D CursorTexture;
	//public Vector2 CursorOffset;

	void Start() {
		Globals.DialogueWindow = DialogueWindow;
		Globals.NotificationWindow = NotificationWindow;
		Globals.FadePanel = FadePanel;
		Globals.GameOverPanel = GameOverPanel;

		Globals.UpperBoundary = UpperBoundary;
		Globals.LowerBoundary = LowerBoundary;

		// Stop menu music
		Destroy(Globals.PeristentMusic);

	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.P)) {
			Globals.GameOver();
		}
	}

	private void OnMouseEnter() {
		//Cursor.visible = false;
		//Cursor.SetCursor(CursorTexture, CursorOffset, CursorMode.Auto);
	}

}
