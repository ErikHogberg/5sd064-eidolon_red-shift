using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxHostScript : MonoBehaviour {

	public float speed;


	// Use this for initialization
	void Start() {

	}

	// Update is called once per frame
	void Update() {

		transform.localPosition = new Vector3(
			transform.position.x * speed,
			transform.localPosition.y,
			transform.localPosition.z
		);

	}
}
