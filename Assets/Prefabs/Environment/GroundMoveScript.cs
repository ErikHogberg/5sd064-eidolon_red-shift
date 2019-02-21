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


	private Vector3 offset;

	public Vector3 buffer;

	// Use this for initialization
	void Start() {
		//offset = transform.position - player.transform.position;
		//buffer = new Vector3(3, 3, 3);
	}

	//*
	// Update is called once per frame
	void LateUpdate() {
		// FIXME: null ref exception on player death, as player game object is destroyed
		if (player.transform.position.x > maxX) {
			//transform.localPosition += new Vector3(-Time.deltaTime * speed, 0, 0);
			transform.localPosition = new Vector3(-player.transform.localPosition.x + maxX, transform.localPosition.y, transform.localPosition.z);
		}

		if (player.transform.position.y > maxY) {
			//transform.localPosition += new Vector3(0, -Time.deltaTime * speed, 0);
			transform.localPosition = new Vector3(transform.localPosition.x, -player.transform.localPosition.y + maxY,  transform.localPosition.z);
		} else if (player.transform.position.y < minY) {
			//transform.localPosition += new Vector3(0, Time.deltaTime * speed, 0);
			transform.localPosition = new Vector3(transform.localPosition.x, -player.transform.localPosition.y + minY,  transform.localPosition.z);
		}

	}
	// */

	/*
	// Update is called once per frame
	void LateUpdate() {

		Vector3 currentOffset = transform.position - player.transform.position;

		Vector3 diff = currentOffset - offset;

		Vector3 newCameraPos = transform.position;

		if (Mathf.Abs(diff.x) > buffer.x) {
			float adjust;
			if (diff.x > 0) {
				adjust = buffer.x;
			} else {
				adjust = -buffer.x;
			}
			newCameraPos.x = player.transform.position.x + offset.x - adjust;
		}



		transform.position = newCameraPos;

	}
	// */

}
