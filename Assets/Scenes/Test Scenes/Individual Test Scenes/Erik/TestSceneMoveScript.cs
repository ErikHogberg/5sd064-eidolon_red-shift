using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSceneMoveScript : MonoBehaviour {
	public float Speed = 10;

	void Update() {
		float x = Input.GetAxis("Horizontal");

		var pos = transform.position;
		pos.x += x * Speed * Time.deltaTime;
		transform.position = pos;
	}
}
