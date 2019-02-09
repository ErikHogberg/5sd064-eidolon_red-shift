using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMoveScript : MonoBehaviour {

	public GameObject player;

	public float speed = 5;

	//public float minX;
	public float maxX = 5;
	public float maxY = 2;
	public float minY = -2;

	// Use this for initialization
	void Start() {

	}

	// Update is called once per frame
	void FixedUpdate() {
		if (player.transform.position.x > maxX) {
			transform.localPosition += new Vector3(-Time.deltaTime * speed, 0, 0);
		}

		if (player.transform.position.y > maxY) {
			transform.localPosition += new Vector3(0, -Time.deltaTime * speed, 0);
		} else if (player.transform.position.y < minY) {
			transform.localPosition += new Vector3(0, Time.deltaTime * speed, 0);
		}

	}
}
