using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockAxisScript : MonoBehaviour {

	public bool LockX = false;
	public bool LockY = false;

	private Vector2 initPos;

	// Start is called before the first frame update
	void Start() {
		initPos = transform.position;
	}

	// Update is called once per frame
	void LateUpdate() {
		Vector3 pos = transform.position;

		if (LockX) {
			pos.x = initPos.x;
		}

		if (LockY) {
			pos.y = initPos.y;
		}

		transform.position = pos;
	}
}
