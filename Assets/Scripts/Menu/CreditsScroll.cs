using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScroll : MonoBehaviour {


	public float ScrollSpeed;
	public float SpaceSpeed = 2.0f;
	public float ShiftSpeed = 2.0f;

	void Update() {
		float speed = ScrollSpeed;

		if (Input.GetKey(KeyCode.Space)) {
			speed *= SpaceSpeed;
		}

		if (Input.GetKey(KeyCode.LeftShift)) {
			speed *= ShiftSpeed;
		}

		Vector3 pos = transform.position;
		pos.y += speed * Time.deltaTime;
		transform.position = pos;

	}
}
