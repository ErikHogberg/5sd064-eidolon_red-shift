using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxHostScript : MonoBehaviour {

	public double speed;


	// Use this for initialization
	void Start() {

	}

	// Update is called once per frame
	void FixedUpdate() {

		transform.localPosition = new Vector3(
			(float)(transform.position.x * speed),
			transform.localPosition.y,
			transform.localPosition.z
		);

	}
}
