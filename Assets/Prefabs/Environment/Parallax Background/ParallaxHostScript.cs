using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxHostScript : MonoBehaviour {

	// Use this for initialization
	void Start() {


		/*
		foreach (Transform tr in transform) {
			if (tr.tag == "Parallax Layer") {
				tr.GetComponent<GameObject>();
				//Debug.Log("fount layer " + tr.name);
			}
		}
		 */
	}

	// Update is called once per frame
	void Update() {
		//Debug.Log("Host update");

		foreach (ParallaxScript item in GetComponentsInChildren<ParallaxScript>()) {
			//Debug.Log("found layer " + item.name);
			item.transform.position = new Vector3(
				transform.position.x * item.speed,
				item.transform.position.y,
				item.transform.position.z
			);
		}

	}
}
