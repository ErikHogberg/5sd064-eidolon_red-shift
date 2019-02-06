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

		foreach (SpriteRenderer item in GetComponentsInChildren<SpriteRenderer>()) {
			item.transform.position = new Vector3(
				transform.position.x * speed, // FIXME: make compatible with repeating background script
				item.transform.position.y,
				item.transform.position.z
			);
		}

	}
}
