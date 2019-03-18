using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthScript : MonoBehaviour {

	public float WorldZ;

	void Start() {

	}

	void Update() {
		Vector3 position = transform.parent.localPosition;

		float cameraHalfHeight = Camera.main.orthographicSize;

		position.z = -1.0f + (transform.position.y + cameraHalfHeight) / (cameraHalfHeight * 2.0f) * 1.0f;

		transform.parent.localPosition = position;

		WorldZ = transform.parent.position.z;
	}
}
