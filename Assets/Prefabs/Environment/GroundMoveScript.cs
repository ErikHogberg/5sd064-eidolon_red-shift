using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMoveScript : MonoBehaviour {

	public GameObject player;

	public float speed = 5;

	public float maxX = 5;
	public float maxY = 2;
	public float minY = -2;


	private Vector3 offset;

	public Vector3 buffer;

	public bool HaltScroll = false;
	private bool scrollBack = false;

	void Start() {
		Assets.Scripts.Globals.Ground = gameObject;
	}

	void LateUpdate() {

		if (player.transform.position.y > maxY) {
			transform.localPosition = new Vector3(transform.localPosition.x, -player.transform.localPosition.y + maxY, transform.localPosition.z);
		} else if (player.transform.position.y < minY) {
			transform.localPosition = new Vector3(transform.localPosition.x, -player.transform.localPosition.y + minY, transform.localPosition.z);
		}

		if (HaltScroll) {
			scrollBack = true;
			return;
		}

		if (scrollBack) {
			if (player.transform.position.x > maxX) {
				transform.localPosition += new Vector3(-Time.deltaTime * speed, 0, 0);
			} else {
				scrollBack = false;
			}
		} else {
			if (player.transform.position.x > maxX) {
				transform.localPosition = new Vector3(-player.transform.localPosition.x + maxX, transform.localPosition.y, transform.localPosition.z);
			}
		}


	}

	/*
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
