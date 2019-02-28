using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairScript : MonoBehaviour {

	private Vector3 mousePosition;

	void Start() {
		Cursor.visible = false;

	}

	void LateUpdate() {
		mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.position = new Vector2(mousePosition.x, mousePosition.y);
	}

}
