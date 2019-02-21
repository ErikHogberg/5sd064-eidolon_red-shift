using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxHostScript : MonoBehaviour {

	public double speed;

	private float offsetX = 0.0f;

	// Use this for initialization
	void Start() {

	}

	// Update is called once per frame
	void FixedUpdate() {

		/*
		Vector3 localPosition = transform.localPosition;
		localPosition.x = (float)(transform.parent.localPosition.x * speed) + offsetX;

		transform.localPosition = localPosition;
		 */

	}

	public void AddOffset(float offsetX) {
		this.offsetX += offsetX;
	}

}
