using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockAxisScript : MonoBehaviour {

	public bool LockX = false;
	public bool LockY = false;

	private Vector2 initPos;
	private Vector2 groundInitPos;

	void Start() {
		initPos = transform.position;
		//groundInitPos = Globals.Ground.transform.position;
	}

	void Update() {
		Vector3 pos = transform.position;
		if (groundInitPos == null) {
			groundInitPos = Globals.Ground.transform.position;
		}
		if (groundInitPos == null) {
			return;
		}

		if (!LockX) {
			//pos.x = initPos.x;
			pos.x = Globals.Ground.transform.position.x - groundInitPos.x + initPos.x;
		}

		if (!LockY) {
			//pos.y = initPos.y;
			pos.y = Globals.Ground.transform.position.y - groundInitPos.y + initPos.y;
		}

		transform.position = pos;
	}
}
